using System;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

//TODO: 
//Set up input to move target
//Set up active map. 
//Find angle to target
//Rotate spell to face Target 
//Make decal VFX for target 

public class SpellActivationBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPos;

    private Vector3 _pos;

    [SerializeField]
    private Transform _targetPos;   //This is the game object that should be moved while casting 

    [SerializeField]
    private InputActionAsset _inputAction;

    private Spell _activeSpell;


    [SerializeField]
    private GameObject _playerWSCanvas;

    public bool _casting { private set; get; }
    void Start()
    {
        //This should be replaced with a reference to the spell focus
        _spawnPos = transform;

        _inputAction.actionMaps[1].Enable();
        _inputAction.actionMaps[2].Disable();
    }
    void Update()
    {
        _pos = _spawnPos.position;
    }
    public void ChangeSpell(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _inputAction.actionMaps[0].Disable();

            _inputAction.actionMaps[2].Enable();
            _playerWSCanvas.SetActive(!_playerWSCanvas.activeSelf);
        }
        if (ctx.canceled)
        {
            _inputAction.actionMaps[0].Enable();
            _inputAction.actionMaps[2].Disable();
            _playerWSCanvas.SetActive(!_playerWSCanvas.activeSelf);
        }
    }
    private string activeSpellDebug = "";
    public void SelectActiveSpell(Spell spell)
    {
        _activeSpell = spell;
    }
    public void CastSpell(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _targetPos.position = transform.position;
            _targetPos.gameObject.SetActive(true);
            _casting = true;
            //            _activeSpell.CastSpell(transform);
            _inputAction.actionMaps[3].Enable();
        }
        if (ctx.canceled)
        {
            //          _casting = false;
            _inputAction.actionMaps[3].Disable();
            _targetPos.gameObject.SetActive(false);

        }
    }

    Transform electrico;
    public void ActivateSpell(InputAction.CallbackContext ctx)
    {
        if (_activeSpell == null) return;
        if (ctx.performed)
        {
            _activeSpell.CastSpell(transform, _targetPos, new Vector3());
        }
    }
}
