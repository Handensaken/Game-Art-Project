using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BallsOfSteelBehaviour : MonoBehaviour
{
    private SphereCollider sphereCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        StartCoroutine(WaitAndExecute(SetHitbox));
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    private IEnumerator WaitAndExecute(Action a)
    {
        yield return new WaitForSeconds(3.7f);
        a();
    }
    private void SetHitbox()
    {
        sphereCollider.enabled = true;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("boom");
            sphereCollider.enabled = false;
        }
    }

}
