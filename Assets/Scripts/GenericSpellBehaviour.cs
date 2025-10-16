using Unity.Cinemachine;
using UnityEngine;

public class GenericSpellBehaviour : MonoBehaviour
{
    protected GameObject player;
    protected Transform castingPos;
    protected Vector3 travelDir;
    protected Vector3 target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void GetData(Vector3 dir, Vector3 _target, Transform origin, Transform playerA)
    {
        target = _target;
        travelDir = dir;    //borde sättas från castingpositonen
        castingPos = origin;    //borde bli onödig
        player = playerA.gameObject; //borde bli onödig
    }
}
