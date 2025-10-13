using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class FireballBehaviour : MonoBehaviour
{
    private Vector3 _boomPos;

    private Vector3 travelDir;

    [SerializeField]
    private float _fireballSpeed;

    Vector3 _spellOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, travelDir * Mathf.Infinity, Color.magenta);
    }

    public void GetData(Vector3 dir, Vector3 target, Vector3 offset)
    {
        _boomPos = target;
        travelDir = dir;
        _spellOffset = offset;
        StartCoroutine(SpellTravel());
    }


    private IEnumerator SpellTravel()
    {
        yield return Anticipation();
        Vector3 v = _boomPos - transform.position;

        while (true)
        {
            v = _boomPos - transform.position;
            Debug.Log(v);
            transform.Translate(travelDir * _fireballSpeed * Time.deltaTime, Space.World);
            if (v.y > -0.1 && v.y < 0.1)
                break;
            yield return null;
        }

        transform.GetChild(2).GetComponent<VisualEffect>().enabled = true;
        float t = 0;
        while (t < 1)
        {
            yield return new WaitForSeconds(0.001f);
            t += 0.01f;
            transform.GetChild(1).localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0f, 0f, 0f), t);
        }
        Debug.Log("Should boom");
    }
    private IEnumerator Anticipation()
    {
        transform.GetChild(0).GetComponent<VisualEffect>().enabled = true;
        for (int i = 0; i < 12; i++)
        {
            yield return new WaitForSeconds(0.1f);
        }

        Transform ball = transform.GetChild(1);
        ball.localScale = new Vector3(0, 0, 0);
        ball.GetComponent<VisualEffect>().enabled = true;
        float t = 0;
        while (t < 1)
        {
            yield return new WaitForSeconds(0.01f);
            t += 0.01f;
            ball.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0.5f, 0.5f, 0.5f), t);
        }
        yield return new WaitForSeconds(1);
    }
}
