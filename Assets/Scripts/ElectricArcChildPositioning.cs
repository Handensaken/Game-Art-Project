using System.Collections;
using Unity.Collections;
using UnityEngine;

public class ElectricArcChildPositioning : GenericSpellBehaviour
{
    private Transform[] childObjects = new Transform[4];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            //   Debug.Log("running child gathering");
            childObjects[i - 1] = transform.GetChild(i);
        }

    }
    void Start()
    {
        /*Quaternion toRotation = Quaternion.LookRotation(target - player.transform.position, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1000);*/
    }


    float f;
    GameObject oldChild;
    float fd = 0;

    // Update is called once per frame
    void Update()
    {

        //StartCoroutine(LerpTimer(1, x => fd = x, 0));
        //Debug.Log(fd);

        /*  var d = childObjects[3].position;
          Debug.Log("FD is " + fd);
          childObjects[3].position = Vector3.Lerp(spellOrigin.position, d + spellDir.normalized * f, fd);*/

        fd += Time.deltaTime;
        if (fd > 1)
        {
            Destroy(oldChild);
            Destroy(gameObject);
        }
    }
    public override void GetData(Vector3 dir, Vector3 _target, Transform origin, Transform playerA)
    {
        base.GetData(dir, _target, origin, playerA);
        dir = target - origin.position;
        f = Vector3.Distance(origin.position, target) - 3;
        // StartCoroutine(LerpTimer(1, (x) => { fd = x; }, 0));
        // childObjects[3].position = childObjects[3].position + dir.normalized * f;
        //    childObjects[3].position = childObjects[3].position + dir.normalized * f;

        RaycastHit hit;
        if (Physics.Raycast(_target, Vector3.up, out hit, 5))
        {
            if (hit.transform.gameObject.CompareTag("ElectricalBox"))
            {
                target = hit.transform.Find("LightningTarget").transform.position;
            }
        }

        childObjects[3].position = target;

        childObjects[2].position = childObjects[2].position + dir.normalized * (f * 0.66f) + new Vector3(0, 2, 0);

        childObjects[1].position = childObjects[1].position + dir.normalized * (f * 0.33f) + new Vector3(0, 2, 0);
        oldChild = childObjects[0].gameObject;
        // Debug.Log(childObjects[0]);
        childObjects[0].parent = origin;
    }

    private IEnumerator LerpTimer(float totalTime, System.Action<float> SetTVal, float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < totalTime * 10; i++)
        {
            SetTVal(i / 100);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
