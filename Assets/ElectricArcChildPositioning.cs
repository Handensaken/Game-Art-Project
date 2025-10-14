using System.Collections;
using Unity.Collections;
using UnityEngine;

public class ElectricArcChildPositioning : MonoBehaviour
{
    private Transform[] childObjects = new Transform[4];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            childObjects[i - 1] = transform.GetChild(i);
        }
    }

    Transform spellOrigin;
    Transform spellTarget;
    Vector3 spellDir;

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
        if (fd > 3)
        {
            Debug.Log("should destroy");
            Destroy(gameObject);

        }
        else
        {
            Debug.Log(fd);
        }

    }
    public void GetData(Transform origin, Transform target, Vector3 dir)
    {
        spellOrigin = origin;
        spellTarget = target;
        f = Vector3.Distance(transform.position, spellTarget.position) - 3;
        // StartCoroutine(LerpTimer(1, (x) => { fd = x; }, 0));
        childObjects[3].position = childObjects[3].position + spellDir.normalized * f;

        childObjects[2].position = childObjects[2].position + spellDir.normalized * (f * 0.66f) + new Vector3(0, 2, 0);

        childObjects[1].position = childObjects[1].position + spellDir.normalized * (f * 0.33f) + new Vector3(0, 2, 0);
        oldChild = childObjects[0].gameObject;
        childObjects[0].parent = spellOrigin;
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
