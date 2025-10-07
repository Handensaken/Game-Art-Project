using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class uiScript : MonoBehaviour
{
	public GameObject[] sections;
	private int currentSection = 0;
	
	public Image targetWeaponImage;
	public Sprite[] sprites;
	public int maximumWeaponInt = 5;
	private int currentWeaponInt = 0;
	
	//Holy fuck im lazy, this shit aint gonna be optimized anyway so imma bullshit lol

	
	
	
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

    public void downClick(InputAction.CallbackContext ctx)
    {
	    if (ctx.performed)
	    {
		    if (currentSection <= 0)
		    {
			    sections[currentSection].SetActive(false);
			    currentSection += 1;
			    sections[currentSection].SetActive(true);
			    Debug.Log(currentSection);
		    }
		    else
		    {
			    sections[currentSection].SetActive(false);
			    currentSection = 0;
			    sections[currentSection].SetActive(true);
			    Debug.Log(currentSection);
				    
		    }
	    }
    }
    
    public void rightClick(InputAction.CallbackContext ctx)
    {
	    if (ctx.performed && currentSection == 1)
	    {
		    if (currentWeaponInt <= maximumWeaponInt - 1)
		    {
			    currentWeaponInt += 1;
			    targetWeaponImage.sprite = sprites[currentWeaponInt];
			    Debug.Log(currentWeaponInt);
		    }
		    else
		    {
			    currentWeaponInt = 0;
			    targetWeaponImage.sprite = sprites[currentWeaponInt];
		    }
	    }
    }
    public void leftClick(InputAction.CallbackContext ctx)
    {
	    if (ctx.performed && currentSection == 1)
	    {
		    if (currentWeaponInt > 0)
		    {
			    currentWeaponInt -= 1;
			    targetWeaponImage.sprite = sprites[currentWeaponInt];
			    Debug.Log(currentWeaponInt);
			  
		    }
		    else
		    {
			    currentWeaponInt = maximumWeaponInt;
			    targetWeaponImage.sprite = sprites[currentWeaponInt];
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
