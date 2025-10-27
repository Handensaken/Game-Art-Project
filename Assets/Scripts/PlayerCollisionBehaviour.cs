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
    public bool collided;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cuck"))
        {
            collided = true;
            Debug.Log("Hit a cuck");

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            GameObject g = Instantiate(collisionPuff, pos, rot);
            Destroy(g, 1.5f);


            GetComponent<PlayerInput>().enabled = false;

            //GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Disable();
            // collision.gameObject.GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Disable();
            collision.gameObject.GetComponent<PlayerInput>().enabled = false;
            StartCoroutine(ReEnableActionMap(collision.gameObject));
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Stun");

            collision.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Stun");
            GetComponent<Rigidbody>().AddForce((transform.position - collision.transform.position) * 5f, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.transform.position - transform.position) * 5f, ForceMode.Impulse);
        }
    }

    private IEnumerator ReEnableActionMap(GameObject other)
    {
        yield return new WaitForSeconds(2.4f);
        // GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Enable();
        GetComponent<PlayerInput>().enabled = true;

        //other.GetComponent<PlayerMovementScript>().playerInputActionAsset.actionMaps[0].Enable();
        other.GetComponent<PlayerInput>().enabled = true;

        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        collided = false;
    }
}
