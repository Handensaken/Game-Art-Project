using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "GreenSpell", menuName = "Assets/ScriptableObjects/GreenSpell")]
public class GreenSpell : Spell
{
    [SerializeField] private GameObject GreenEffect;

    public override void CastSpell(Transform origin, Transform target, Vector3 offset)
    {
        SpellEffect = GreenEffect;
        offset = new Vector3(0, 0, 0);
        base.CastSpell(target, target, offset);
        g.GetComponent<VisualEffect>().enabled = true;
        Destroy(g, 10f);
    }
}
