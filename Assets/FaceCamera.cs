using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camPosition = Camera.main.transform.position;
    }
    Vector3 camPosition;
    // Update is called once per frame
    void Update()
    {
        Vector3 lookPos = new Vector3(camPosition.x, camPosition.y, camPosition.z);
        transform.LookAt(lookPos);
    }
}
