using UnityEngine;

public class CuckPervert : MonoBehaviour
{
    [SerializeField]
    GameObject Cuck;

    [SerializeField] private bool shouldSpawnCuck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (shouldSpawnCuck)
        {
            Cuck.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
