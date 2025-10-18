using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFXToAnimationHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _runningParticlePrefab;
    [SerializeField] SpellActivationBehaviour spellActivationBehaviour;

    private VisualEffect _runningEffect;

    [Header("Spells")]
    [SerializeField] private Transform staffCastingPos;

    [Header("Fireball")]
    [SerializeField] private GameObject FireSwirl;

    [SerializeField] private GameObject FireBall;

    [SerializeField] private GameObject FireSpell;

    [Header("Lightning spell")]
    [SerializeField] private GameObject Lightning;

    [Header("Green")]
    [SerializeField] private GameObject GreenSpell;
    [Header("Balls of steel")]
    [SerializeField] private GameObject BOS;



    //This helps position and initiate effects
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _runningEffect = _runningParticlePrefab.GetComponent<VisualEffect>();
        _runningParticlePrefab.transform.parent = transform;
        _runningEffect.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {

    }


    //Animation event functions
    public void SetRunningParticles(int boolFlag)
    {
        if (boolFlag == 1)
        {
            _runningEffect.enabled = true;
        }
        else if (boolFlag == 0)
        {
            _runningEffect.enabled = false;
        }
        else
        {
            Debug.LogWarning("Running particles animation event passes an unallowed parameter value. Set 0 or 1. "
             + "Or improper handling of activation. Talk to Max if you're sure you pass the correct values");
        }
    }
    GameObject fireSwirl;

    public void SpawnFireSwirl()
    {
        fireSwirl = Instantiate(FireSwirl, staffCastingPos.position, quaternion.identity);
        StartCoroutine(CheatUpdate(1.1f, UpdateSwirlToPos));
        Destroy(fireSwirl, 1.2f);
    }
    private void UpdateSwirlToPos()
    {
        fireSwirl.transform.position = staffCastingPos.position;
    }
    private IEnumerator CheatUpdate(float time, Action shitToDo)
    {
        float t = 0;
        while (t < time)
        {
            t += Time.deltaTime;
            shitToDo();
            yield return null;
        }
    }
    GameObject fireball;
    public void SpawnFireball()
    {
        fireball = Instantiate(FireBall, staffCastingPos.position, quaternion.identity, staffCastingPos);

    }
    public void CastFireSpell()
    {
        Destroy(fireball);
        spellActivationBehaviour.SpellDistCal(FireSpell, true);
    }

    public void CastLightningSpell()
    {
        Debug.Log(Lightning);
        spellActivationBehaviour.SpellDistCal(Lightning, true);
    }
    public void CastBOS()
    {
        spellActivationBehaviour.SpellDistCal(BOS, false);
    }
    public void CastGreen()
    {
        spellActivationBehaviour.SpellDistCal(GreenSpell, false);
    }

}
