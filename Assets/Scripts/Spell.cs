using UnityEngine;
[CreateAssetMenu(menuName = "Assets/ScriptableObjects")]
public class Spell : ScriptableObject
{
    protected GameObject SpellEffect;
    protected GameObject g;

    protected Vector3 dir;
    public virtual void CastSpell(Transform origin, Transform target)
    {
        g = Instantiate(SpellEffect, origin.position, SpellEffect.transform.rotation, null);

        dir = target.position - origin.position;
        Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
        g.transform.rotation = Quaternion.RotateTowards(SpellEffect.transform.rotation, toRotation, 1000);
    }
}
