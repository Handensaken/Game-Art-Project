using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "GreenSpell", menuName = "Assets/ScriptableObjects/GreenSpell")]
public class GreenSpell : Spell
{
    [SerializeField] private GameObject GreenEffect;

    public override void CastSpell(string spell, GameEventManager gameEventManager)
    {
        SpellEffect = GreenEffect;
     
        base.CastSpell("Green", gameEventManager);
        /*g.GetComponent<VisualEffect>().enabled = true;
        Destroy(g, 10f);*/
    }
}
