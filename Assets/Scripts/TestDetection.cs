using System.Data.Common;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
public class TestDetection : MonoBehaviour
{
    [SerializeField] private AiMovement aiMovement;

    [SerializeField] private Image fillImage;

    [SerializeField] private GameObject canvas;

    [SerializeField] private Animator canvasAnim;
    
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
                playerDetecton -= Time.deltaTime / 2;
            }
            if (playerDetecton <= 0)
            {
                playerDetecton = 0;
                canvas.SetActive(false);
            }
            if (playerDetecton < detectionTime / 4 && wasDetected)
            {
                wasDetected = false;
                aiMovement.TargetLost();
                //Debug.Log("No Longer detecting player");
            }


        }
        else
        {
                canvas.SetActive(true);
        }
        
        fillImage.fillAmount = playerDetecton;
    }
    bool detecting;
    bool wasDetected;
    float playerDetecton = 0;
    float detectionTime = 1;
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
                canvasAnim.SetTrigger("Alert");
              //  Debug.Log("Player Was detected");
            }
            else
            {
                playerDetecton += Time.deltaTime/2;
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
