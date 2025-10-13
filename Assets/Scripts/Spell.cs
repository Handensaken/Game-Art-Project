using UnityEngine;
[CreateAssetMenu(menuName = "Assets/ScriptableObjects")]
public class Spell : ScriptableObject
{
    protected GameObject SpellEffect;
    protected GameObject g;

    protected Vector3 dir;

    private Vector3 localDir;
    public virtual void CastSpell(Transform origin, Transform target, Vector3 offset)
    {
        g = Instantiate(SpellEffect, origin.position + offset, SpellEffect.transform.rotation, null);

        dir = target.position - (origin.position + offset);
        localDir = target.position - origin.position;
        Quaternion toRotation = Quaternion.LookRotation(localDir, Vector3.up);
        g.transform.rotation = Quaternion.RotateTowards(SpellEffect.transform.rotation, toRotation, 1000);
    }
}
