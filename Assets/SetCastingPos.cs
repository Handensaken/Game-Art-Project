using UnityEngine;

public class SetCastingPos : MonoBehaviour
{
    Transform castingPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        castingPos = GameObject.Find("CastingPos").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = castingPos.position;
    }
}
