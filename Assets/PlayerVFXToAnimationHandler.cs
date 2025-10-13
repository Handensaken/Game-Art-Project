using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFXToAnimationHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _runningParticlePrefab;

    private VisualEffect _runningEffect;

    //This helps position and initiate effects
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        _runningEffect = _runningParticlePrefab.GetComponent<VisualEffect>();
        _runningParticlePrefab.transform.parent = transform;
        _runningEffect.transform.localPosition = new Vector3(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
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


}
