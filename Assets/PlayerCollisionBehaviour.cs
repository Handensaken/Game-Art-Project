using UnityEngine;

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
        }
    }
}
