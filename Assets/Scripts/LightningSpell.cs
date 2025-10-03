using Unity.Mathematics;
using UnityEngine;


[CreateAssetMenu(menuName = "Assets/ScriptableObjects/Test")]
public class LightningSpell : Spell
{
    [SerializeField]
    private GameObject ElectricArcEffect;

    public int test;
    public override void CastSpell(Transform origin)
    {
        base.CastSpell(origin);
        GameObject g = Instantiate(ElectricArcEffect, origin.position, ElectricArcEffect.transform.rotation, null);
        g.transform.rotation = new quaternion(origin.rotation.x, origin.rotation.y - 90, origin.rotation.z, origin.rotation.w);
    }
}
