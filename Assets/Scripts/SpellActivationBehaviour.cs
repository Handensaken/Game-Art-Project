using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellActivationBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject FireballVFX;
    [SerializeField]
    private GameObject ElectricArcVFX;
    [SerializeField]
    private GameObject _fartVFX;

    [SerializeField]
    private Transform _castingPos;

    private Vector3 _pos;

    [SerializeField]
    private Transform _targetPos;

    [SerializeField]
    private InputActionAsset _inputAction;

    [SerializeField]
    private Spell[] _spells;

    private Spell _activeSpell;


    [SerializeField]
    private GameObject _whoreCanvas;

    private bool _casting;
    void Start()
    {
        _inputAction.actionMaps[1].Enable();
        _inputAction.actionMaps[2].Disable();
    }
    void Update()
    {
        _pos = _castingPos.position;
    }
    public void ChangeSpell(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("MY COCK CAN COUGH");
            _inputAction.actionMaps[0].Disable();

            _inputAction.actionMaps[2].Enable();
            _whoreCanvas.SetActive(!_whoreCanvas.activeSelf);
        }
        if (!_whoreCanvas)
        {
            _inputAction.actionMaps[0].Enable();
            _inputAction.actionMaps[2].Disable();
           // _whoreCanvas.SetActive(false);
        }
    }

    public void SelectActiveSpell()
    {
        Debug.Log("WEEWOOO");   
    }
    public void CastSpell(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _casting = true;
            _activeSpell.CastSpell(transform);
        }
        if (ctx.canceled)
        {
            _casting = false;
        }
    }
    public void Fireball()
    {
        Debug.Log(_pos);
        Instantiate(FireballVFX, _pos, _castingPos.rotation);
    }
    public void ElectricArc(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameObject g = Instantiate(ElectricArcVFX, _pos, ElectricArcVFX.transform.rotation, transform);


        }
    }


    public void Fart()
    {
        Instantiate(_fartVFX, _targetPos.position, Quaternion.identity);
    }
}
