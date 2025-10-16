using UnityEngine;
[CreateAssetMenu(menuName = "Assets/ScriptableObjects")]
public class Spell : ScriptableObject
{
    protected GameObject SpellEffect;
    protected GameObject g;

    protected Vector3 dir;

    private Vector3 localDir;

    protected Vector3 hitPoint;
    public virtual void CastSpell(string spell, GameEventManager gameEventManager)
    {
        gameEventManager.instance.SendAnimationParams(spell);
        /*g = Instantiate(SpellEffect, origin.position + offset, SpellEffect.transform.rotation, null);

        dir = target.position - (origin.position + offset);
        localDir = target.position - player.position;
        Quaternion toRotation = Quaternion.LookRotation(localDir, Vector3.up);
        g.transform.rotation = Quaternion.RotateTowards(SpellEffect.transform.rotation, toRotation, 1000);

        RaycastHit hit;
        if (Physics.Raycast(g.transform.position, dir, out hit, Vector3.Distance(origin.position, target.position)-1))
        {
            Debug.DrawRay(origin.position, dir * hit.distance, Color.magenta);
            Debug.Log(hit.transform.name);
            hitPoint = hit.point;
        }
        else
        {
            hitPoint = target.position;
            Debug.Log("did not hit an obstacle");
        }*/
    }
}
