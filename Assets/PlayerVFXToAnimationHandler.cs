using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFXToAnimationHandler : MonoBehaviour
{
    [SerializeField]
    private VisualEffect _runningEffect;

    //This helps position and initiate effects
    private List<VisualEffect> activeEffects = new List<VisualEffect>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        activeEffects.Add(_runningEffect);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (VisualEffect activeEffect in activeEffects)
        {
            activeEffect.transform.position = transform.position;
        }
    }
    void LateUpdate()
    {
        foreach (VisualEffect activeEffect in activeEffects)
        {
            if (!activeEffect.enabled) activeEffects.Remove(activeEffect);
        }
    }


    //Animation event functions
    public void SetRunningParticles(int boolFlag)
    {
        if (boolFlag == 1 && !activeEffects.Contains(_runningEffect))
        {
            activeEffects.Add(_runningEffect);
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


}
