using UnityEngine;

public class CuckPervert : MonoBehaviour
{
    [SerializeField]
    GameObject Cuck;

    [SerializeField][Tooltip("Having this ticked will spawn a dummy player that can run around the scene. It can't cast spells")] private bool shouldSpawnCuck;
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
