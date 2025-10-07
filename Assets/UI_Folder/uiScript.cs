using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class uiScript : MonoBehaviour
{
	
	public Image targetImage;
	public Sprite[] sprites;
	public int maximumWeaponInt = 5;
	public int currentWeaponInt = 0;
	
	
	
	
	
	
    public float holdRequirement = 1f;
    public Image fillCircle;
    public Image checkMark;

    private float holdTimer = 0;
    private bool isHolding = false;
    private bool isDone = false;


    // Update is called once per frame
    void Update()
    {
	    if(isHolding)
	    {
		    holdTimer += Time.deltaTime;
		    fillCircle.fillAmount = holdTimer / holdRequirement;
		    if(holdTimer >= holdRequirement)
		    {
			    isDone = true;
			    checkMark.gameObject.SetActive(true);
		    }
	    }
    }

    public void rightClick(InputAction.CallbackContext ctx)
    {
	    if (ctx.performed)
	    {
		    if (currentWeaponInt <= maximumWeaponInt - 1)
		    {
			    currentWeaponInt += 1;
			    targetImage.sprite = sprites[currentWeaponInt];
			    Debug.Log(currentWeaponInt);
		    }
		    else
		    {
			    currentWeaponInt = 0;
			    targetImage.sprite = sprites[currentWeaponInt];
		    }
			    
	    }
    }
    public void leftClick(InputAction.CallbackContext ctx)
    {
	    if (ctx.performed)
	    {
		    if (currentWeaponInt > 0)
		    {
			    currentWeaponInt -= 1;
			    targetImage.sprite = sprites[currentWeaponInt];
			    Debug.Log(currentWeaponInt);
			  
		    }
		    else
		    {
			    currentWeaponInt = maximumWeaponInt;
			    targetImage.sprite = sprites[currentWeaponInt];
		    }
			    
	    }
    } 
    
    public void OnHold(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
	        Debug.Log("cFUCK");
	        isHolding = true;
	        //StartHold();
        }else if (ctx.canceled && !isDone)
		{
			Debug.Log("canceled");
			ResetHold();
		}

    }
    
	private void ResetHold()
	{
		isHolding = false;
		holdTimer = 0;
		fillCircle.fillAmount = 0;
	}
    
}
