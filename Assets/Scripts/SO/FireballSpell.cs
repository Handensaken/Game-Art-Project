using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "FireballSpell", menuName = "Assets/ScriptableObjects/FireballSpell")]
public class FireballSpell : Spell
{
    [SerializeField]
    private GameObject FireballEffect;
    //private Vector3 explosionTarget;
    string spellthingy = "Fireball";
    public override void CastSpell(string s, GameEventManager gameEventManager)
    {
        // origin.position = origin.position + new Vector3(0,10,0);
        SpellEffect = FireballEffect;
        // offset = new Vector3(0, 4.5f, 0);
        base.CastSpell(spellthingy, gameEventManager);

        //  g.GetComponent<FireballBehaviour>().GetData(dir, hitPoint, offset, origin, player);

    }
}
