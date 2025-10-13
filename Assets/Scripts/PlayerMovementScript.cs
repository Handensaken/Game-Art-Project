using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement Speed")]
    [SerializeField]
    [Tooltip("Adjust the speed at which the player is able to run (Default: 10)")]
    private float _runSpeed;
    [SerializeField]
    [Tooltip("Adjust the sprinting speed (Default: 15)")]
    private float _sprintSpeed;
    [SerializeField]
    [Tooltip("Adjust the sneaking speed (Default: 5)")]
    private float _sneakSpeed;

    private float activeSpeed;
    [Header("Interpolations")]
    [SerializeField]
    [Tooltip("The speed at which the character is able to rotate (Default: 1000)")]
    private float rotationSpeed = 1000;
    [SerializeField]
    [Tooltip("The time, in seconds, it should take for the player to reach full speed. (Default: 0.15)")]
    private float _startInterpolationSpeed = 0.15f;
    [SerializeField]
    [Tooltip("The time, in seconds, it takes for the player to come to a stop (Default: 0.2)")]
    private float _stopInterpolationSpeed = 0.2f;
    private Vector2 _movementDir;
    [SerializeField]
    private Animator animCTRL;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeSpeed = _runSpeed;
    }

    private float lerpT = 0;
    private float sprintT;
    // Update is called once per frame
    void Update()
    {
        bool casting = GetComponent<SpellActivationBehaviour>()._casting;
        //Remap movement direction to a 3D vector
        Vector3 movementVector = new Vector3(_movementDir.x, 0, _movementDir.y);

        //Set up the true input movement
        Vector3 TrueMovement = movementVector.normalized * activeSpeed * Time.deltaTime;
        //Map the movement as interpolation between zero and the true movement. 
        Vector3 ActiveMovement = Vector3.Lerp(Vector3.zero, TrueMovement, lerpT);


        ActiveMovement = Quaternion.AngleAxis(-45, Vector3.up) * ActiveMovement;
        //Move the character's transform in world space
        transform.Translate(ActiveMovement, Space.World);

        //Align character to direction
        if (ActiveMovement * activeSpeed != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(ActiveMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        float f = Mathf.Clamp(ActiveMovement.magnitude * 100 / 2.4f, 0, 1);
        //sprinting behaviour
        if (f >= 0.8f && !casting)
        {
            f = 1.0f;
            sprintT += Time.deltaTime;
            if (sprintT > 5)
            {
                activeSpeed = _sprintSpeed;
                animCTRL.SetBool("Sprint", true);
            }
        }
        else if (activeSpeed == _sprintSpeed)
        {
            animCTRL.SetBool("Sprint", false);

            sprintT = 0;
            activeSpeed = _runSpeed;
        }
        if (f < 0.5f)
        {
            sprintT = 0;
            animCTRL.SetBool("Sprint", false);
        }
        animCTRL.SetFloat("Blend", f);
        //        Debug.Log(f);
    }

    //Interpolation coroutine. Don't touch 
    private IEnumerator LerpTimer(float targetValue, float totalTime)
    {
        if (targetValue > 0)
        {
            while (lerpT < targetValue)
            {
                yield return new WaitForSeconds(totalTime / 10);
                lerpT += 0.1f;
            }
        }
        else
        {
            while (lerpT > targetValue)
            {
                yield return new WaitForSeconds(totalTime / 10);
                lerpT -= 0.1f;
            }
        }
    }

    //Recieves input call from unity. Don't mess around unless you know shit
    public void Sneak(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            sprintT = 0;
            activeSpeed = _sneakSpeed;
            animCTRL.SetBool("Sprint", false);
            Debug.Log("Sneaky Snitch bip bop");
        }
        else if (context.canceled)
        {
            activeSpeed = _runSpeed;
            Debug.Log("Not a sneaky bitch");
        }
    }
    //This method reads the input system value. Don't mess with it unless you know what you're doing
    public void Movement(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StopAllCoroutines();
            StartCoroutine(LerpTimer(1, _startInterpolationSpeed));
        }
        if (context.canceled)
        {
            StopAllCoroutines();
            if (activeSpeed == _sprintSpeed)
            {
                StartCoroutine(LerpTimer(0, 0.5f));

            }
            else
            {

                StartCoroutine(LerpTimer(0, _stopInterpolationSpeed));
            }
        }
        else
        {
            _movementDir = context.ReadValue<Vector2>();
        }
    }
}
