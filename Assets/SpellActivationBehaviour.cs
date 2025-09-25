using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellActivationBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject FireballVFX;
    [SerializeField]
    private GameObject ElectricArcVFX;
    [SerializeField]
    private GameObject FartVFX;

    [SerializeField]
    private Transform CastingPos;

    private Vector3 pos;

    [SerializeField]
    private Transform targetPos;

    [SerializeField]
    InputActionAsset aa;
    void Start()
    {
        aa.actionMaps[1].Enable();
    }
    void Update()
    {
        pos = CastingPos.position;
    }
    public void Fireball()
    {
        Debug.Log(pos);
        Instantiate(FireballVFX, pos, CastingPos.rotation);
    }
    public void ElectricArc()
    {
        GameObject g = Instantiate(ElectricArcVFX, pos, Quaternion.identity);
        Quaternion rot = new Quaternion(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z, transform.rotation.w);
        g.transform.rotation = rot;
    }
    public void Fart()
    {
        Instantiate(FartVFX, targetPos.position, Quaternion.identity);
    }
}
