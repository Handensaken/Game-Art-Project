using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveOnDisable : MonoBehaviour
{
    [SerializeField]
   private EventSystem eventSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnDisable()
    {
        eventSystem.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
    }
}
