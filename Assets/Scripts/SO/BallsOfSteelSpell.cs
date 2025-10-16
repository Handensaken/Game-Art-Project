using UnityEngine;

[CreateAssetMenu(fileName = "BallsOfSteelSpell", menuName = "Assets/ScriptableObjects/BallsOfSteelSpell")]
public class BallsOfSteelSpell : Spell
{
    [SerializeField]
    private GameObject BoSEffect;
    public override void CastSpell(string spell, GameEventManager gameEventManager)
    {
        SpellEffect = BoSEffect;
       // offset = new Vector3(0, 1.5f, 0);
        base.CastSpell("BoS", gameEventManager);
    }
}
