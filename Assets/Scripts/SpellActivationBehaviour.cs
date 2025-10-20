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

    public GameEventManager _playerGameEventManager;
    public bool _casting { private set; get; }
    void Start()
    {
        //This should be replaced with a reference to the spell focus
        _spawnPos = transform;

        _inputAction.actionMaps[1].Enable();
        _inputAction.actionMaps[2].Disable();

        _playerGameEventManager.instance.OnSendAnimationParams += Test;
    }
    void OnDisable()
    {
        _playerGameEventManager.instance.OnSendAnimationParams -= Test;
    }
    void Update()
    {
        _pos = _spawnPos.position;
        // Debug.DrawRay(castingPos.position, _targetPos.position - castingPos.position * Mathf.Infinity, Color.magenta);

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
    [SerializeField] private Animator playerAnimator;

    private void Test(string s)
    {
        playerAnimator.SetTrigger(s);
    }

    public Transform castingPos;
    public void ActivateSpell(InputAction.CallbackContext ctx)
    {
        if (_activeSpell == null) return;
        if (ctx.performed)
        {
            _activeSpell.CastSpell("", _playerGameEventManager);
        }
    }



    //fuuuuuck

    Vector3 dir;
    Vector3 localDir;
    Vector3 hitPoint;
    public void SpellDistCal(GameObject spell, bool collCheck)
    {
        GameObject g = null;

        dir = _targetPos.position - castingPos.position;
        localDir = _targetPos.position - transform.position;


        if (collCheck)
        {
            RaycastHit hit;
            if (Physics.Raycast(castingPos.position, dir, out hit, Vector3.Distance(castingPos.position, _targetPos.position) - 1))
            {
                Debug.DrawRay(castingPos.position, dir * hit.distance, Color.magenta);
                Debug.Log(hit.transform.name);
                hitPoint = hit.point;

            }
            else
            {
                hitPoint = _targetPos.position;
                Debug.Log("did not hit an obstacle");
            }

            //Instantiate on casting stuff
            g = Instantiate(spell, castingPos.position, spell.transform.rotation, null);

            g.GetComponent<GenericSpellBehaviour>().GetData(dir, hitPoint, castingPos, transform);
        }
        else
        {
            hitPoint = _targetPos.position;
            g = Instantiate(spell, hitPoint, Quaternion.identity, null);
            if (g.GetComponent<GenericSpellBehaviour>() != null)
            {

                g.GetComponent<GenericSpellBehaviour>().GetData(dir, hitPoint, castingPos, transform);
            }
            else
            {
                Destroy(g, 1.5f);
            }

            //instantiate on target pos
        }

    }

}
