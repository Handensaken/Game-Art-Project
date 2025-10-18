using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollisionBehaviour : MonoBehaviour
{
    public GameObject collisionPuff;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cuck"))
        {
            Debug.Log("Hit a cuck");

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject g = Instantiate(collisionPuff, pos, rot);
            Destroy(g, 1.5f);

            GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Disable();
            // collision.gameObject.GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Disable();
            collision.gameObject.GetComponent<PlayerInput>().enabled = false;
            StartCoroutine(ReEnableActionMap(collision.gameObject));

            GetComponent<Rigidbody>().AddForce((transform.position - collision.transform.position) * 2f, ForceMode.VelocityChange);
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.transform.position - transform.position) * 2f, ForceMode.Impulse);
        }
    }

    private IEnumerator ReEnableActionMap(GameObject other)
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Enable();
        //other.GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Enable();
        other.GetComponent<PlayerInput>().enabled = true;

        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }
}
