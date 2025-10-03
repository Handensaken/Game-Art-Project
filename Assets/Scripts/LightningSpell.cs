using Unity.Mathematics;
using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Assets/ScriptableObjects/Test")]
public class LightningSpell : Spell
{
    [SerializeField]
    private GameObject ElectricArcEffect;

    private Transform[] childObjects = new Transform[4];

    public override void CastSpell(Transform origin, Transform target)
    {
        base.CastSpell(origin, target);
        for (int i = 1; i < ElectricArcEffect.transform.childCount; i++)
        {
            childObjects[i - 1] = g.transform.GetChild(i);
        }
        SpellEffect = ElectricArcEffect;
        // g.transform.GetChild(4).transform.position = target.position;
        float f = Vector3.Distance(g.transform.position, target.position) - 3;

     //   var d = childObjects[3].position;
      //  Vector3.Lerp(origin.position, childObjects[3].position + dir.normalized * f, Time.deltaTime);
        childObjects[3].position = childObjects[3].position + dir.normalized * f;

        childObjects[2].position = childObjects[2].position + dir.normalized * (f * 0.66f) + new Vector3(0, 2, 0);

        childObjects[1].position = childObjects[1].position + dir.normalized * (f * 0.33f) + new Vector3(0, 2, 0);

        childObjects[0].parent = origin;

    }
}