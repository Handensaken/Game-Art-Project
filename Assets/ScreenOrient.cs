using UnityEngine;

public class ScreenOrient : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position + new Vector3(0,5,0);
        Quaternion rot = Camera.main.transform.rotation;
        transform.rotation = rot;
    }
}
