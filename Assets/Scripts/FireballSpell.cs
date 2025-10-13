using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "FireballSpell", menuName = "Assets/ScriptableObjects/FireballSpell")]
public class FireballSpell : Spell
{
    [SerializeField]
    private GameObject FireballEffect;
    private Vector3 explosionTarget;

    public override void CastSpell(Transform origin, Transform target, Vector3 offset)
    {
       // origin.position = origin.position + new Vector3(0,10,0);
        SpellEffect = FireballEffect;
        offset = new Vector3(0, 3, 0);
        base.CastSpell(origin, target, offset);

        RaycastHit hit;
        if (Physics.Raycast(origin.position, dir, out hit, Vector3.Distance(origin.position, target.position)))
        {
            Debug.DrawRay(origin.position, dir * hit.distance, Color.magenta);
            Debug.Log("Hit an obstacle");
            explosionTarget = hit.point;
        }
        else
        {
            explosionTarget = target.position;
            Debug.Log("did not hit an obstacle");
        }
        g.GetComponent<FireballBehaviour>().GetData(dir, explosionTarget, offset);

    }
}
