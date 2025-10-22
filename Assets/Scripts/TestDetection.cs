using UnityEngine;
using UnityEngine.Animations;

public class TestDetection : MonoBehaviour
{
    [SerializeField] private AiMovement aiMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!detecting)
        {
            if (playerDetecton > 0)
            {
                playerDetecton -= Time.deltaTime/2;
            }
            if (playerDetecton < 0) playerDetecton = 0;

            if (playerDetecton < detectionTime / 4 && wasDetected)
            {
                wasDetected = false;
                aiMovement.TargetLost();
                //Debug.Log("No Longer detecting player");
            }
        }
    }
    bool detecting;
    bool wasDetected;
    float playerDetecton = 0;
    float detectionTime = 2;
    Collider ObscuringObject;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obscuring"))
        {
            detecting = false;
            if (playerDetecton > 0)
            {
                aiMovement.TargetLost();
            }
            ObscuringObject = other;
            playerDetecton = 0;

            return;
        }
        else if (other.CompareTag("Player") && ObscuringObject == null)
        {
            detecting = true;
            //  Debug.Log("Detecting");

            if (playerDetecton >= detectionTime && !wasDetected)
            {
                wasDetected = true;
                aiMovement.StartChasing(other.transform);
              //  Debug.Log("Player Was detected");
            }
            else
            {
                playerDetecton += Time.deltaTime;
            }
        }
        ObscuringObject = null;
        // Debug.Log(other.gameObject.name);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            detecting = false;
            if (playerDetecton < detectionTime / 4)
            {

             aiMovement.TargetLost();
            //    Debug.Log("No Longer detecting player");
            }
            // playerDetecton = 0;
        }
    }
}
