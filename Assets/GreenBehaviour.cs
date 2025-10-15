using System.Collections;
using UnityEngine;

public class GreenBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(wait());
    }
    float f;
    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator wait()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            f += 0.01f;
            transform.localScale = Vector3.Slerp(new Vector3(0.1f,0.1f,0.1f), new Vector3(1,1,1), f);
        }

    }
}
