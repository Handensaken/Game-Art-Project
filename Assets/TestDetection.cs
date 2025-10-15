using UnityEngine;

public class TestDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float playerDetecton = 0;
    float detectionTime = 2;
    Collider ObscuringObject;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obscuring"))
        {
            ObscuringObject = other;
            playerDetecton = 0;
            return;
        }
        else if (other.CompareTag("Player") && ObscuringObject == null)
        {
          //  Debug.Log("Detecting");
            playerDetecton += Time.deltaTime;
            if (playerDetecton >= detectionTime)
            {
                Debug.Log("Player Was detected");
            }
        }
        ObscuringObject = null;
        // Debug.Log(other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("No Longer detecting player");
            playerDetecton = 0;
        }
    }
}
