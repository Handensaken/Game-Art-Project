using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BallsOfSteelBehaviour : GenericSpellBehaviour
{
    private SphereCollider sphereCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = transform.position + new Vector3(0, 1.5f, 0);
        sphereCollider = GetComponent<SphereCollider>();
        StartCoroutine(WaitAndExecute(SetHitbox));
        Destroy(gameObject, 10f);
        transform.LookAt(player.transform);
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
