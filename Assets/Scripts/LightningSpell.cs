using Unity.Mathematics;
using UnityEngine;

public class LightningSpell : Spell
{
    [SerializeField]
    private GameObject ElectricArcEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void CastSpell(Transform origin)
    {
        base.CastSpell(origin);
        GameObject g = Instantiate(ElectricArcEffect, origin.position, ElectricArcEffect.transform.rotation, null);
        g.transform.rotation = new quaternion(origin.rotation.x, origin.rotation.y - 90, origin.rotation.z, origin.rotation.w);
    }
}
