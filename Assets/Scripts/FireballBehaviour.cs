using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class FireballBehaviour : GenericSpellBehaviour
{
    [SerializeField]
    private float _fireballSpeed;

    Vector3 _spellOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //    player = GameObject.FindGameObjectWithTag("Player");
    }
    //float timer;
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            castingPos = player.GetComponent<SpellActivationBehaviour>().castingPos;
        }
        //timer += Time.deltaTime;
        if (transform.GetChild(1).GetComponent<VisualEffect>().enabled)
        {
            Destroy(gameObject, 10); // borde flyttas maybe
        }

    }


    public override void GetData(Vector3 dir, Vector3 target, Transform origin, Transform playerA)
    {
        base.GetData(dir, target, origin, playerA);
        StartCoroutine(SpellTravel());  //borde startas av ett amimationsevent
    }
    private IEnumerator SpellTravel()
    {
        transform.GetChild(0).GetComponent<VisualEffect>().enabled = true;
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

        Vector3 v = target - transform.position;

        while (true)
        {
            v = target - transform.position;
            transform.Translate(travelDir * _fireballSpeed * Time.deltaTime, Space.World);
            if (v.y > -0.1 && v.y < 0.1)
                break;
            yield return null;
        }

        transform.GetChild(1).GetComponent<VisualEffect>().enabled = true;
        float t = 0;
        Vector3 aaa = transform.GetChild(0).localScale;
        while (t < 0.5f)
        {
            yield return new WaitForSeconds(0.001f);
            t += 0.01f;
            transform.GetChild(0).localScale = Vector3.Lerp(aaa, new Vector3(0f, 0f, 0f), t);
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        transform.GetChild(0).GetComponent<VisualEffect>().enabled = false;

    }
}
