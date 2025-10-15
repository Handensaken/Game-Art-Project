using UnityEngine;
using UnityEngine.InputSystem;

public class SpellTargetPositioning : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Vector2 _movementDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(_movementDir.x, 0, _movementDir.y);
        movement = Quaternion.AngleAxis(-45, Vector3.up) * movement;
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public void RecieveInput(InputAction.CallbackContext ctx)
    {
        _movementDir = ctx.ReadValue<Vector2>();
    }
}
