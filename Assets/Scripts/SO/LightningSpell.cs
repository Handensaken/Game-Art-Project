using Unity.Mathematics;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Assets/ScriptableObjects/LightningSpell")]
public class LightningSpell : Spell
{
    [SerializeField]
    private GameObject ElectricArcEffect;

    private Transform[] childObjects = new Transform[4];

    public override void CastSpell(Transform origin, Transform target, Vector3 offset)
    {
        SpellEffect = ElectricArcEffect;
        offset = new Vector3(0, 2.5f, 0);
        base.CastSpell(origin, target, offset);
        for (int i = 1; i < ElectricArcEffect.transform.childCount; i++)
        {
            childObjects[i - 1] = g.transform.GetChild(i);
        }
        // g.transform.GetChild(4).transform.position = target.position;
        float f = Vector3.Distance(g.transform.position, hitPoint) - 3;

        //   var d = childObjects[3].position;
        //  Vector3.Lerp(origin.position, childObjects[3].position + dir.normalized * f, Time.deltaTime);
        childObjects[3].position = childObjects[3].position + dir.normalized * f;

        childObjects[2].position = childObjects[2].position + dir.normalized * (f * 0.66f) + new Vector3(0, 2, 0);

        childObjects[1].position = childObjects[1].position + dir.normalized * (f * 0.33f) + new Vector3(0, 2, 0);

        childObjects[0].parent = origin;
        Destroy(childObjects[0].gameObject, 3);
    }
}