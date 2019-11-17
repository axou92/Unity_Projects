using UnityEngine;
using UnityEngine.EventSystems;

public class JumpScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    static public bool isJump = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isJump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isJump = false;
    }
}
