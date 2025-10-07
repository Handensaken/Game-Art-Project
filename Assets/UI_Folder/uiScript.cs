using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class uiScript : MonoBehaviour
{
    public float holdRequirement = 1f;
    public Image fillCircle;

    private float holdTimer = 0;
    private bool isHolding = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (isHolding = true)
	    {
		    holdTimer += Time.deltaTime;
		    fillCircle.fillAmount = holdTimer / holdRequirement;
		    if(holdTimer >= holdRequirement)
		    {
			    
		    }
	    }
    }

    public void OnHold(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
	        
	        isHolding = true;
        }else if (ctx.canceled)
		{
			Debug.Log("canceled");
			//ResetHold();
		}

    }
    
    public void Test(InputAction.CallbackContext ctx)
    {
	    if (ctx.performed)
	    {
		    Debug.Log("test");
	    }

    }
    
	private void ResetHold()
	{
		isHolding = false;
		holdTimer = 0;
		fillCircle.fillAmount = 0;
	}
    
}
