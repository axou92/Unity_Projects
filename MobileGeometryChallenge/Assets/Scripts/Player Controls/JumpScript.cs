using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> This script allows to know if the player press the jump button or not. </summary>
public class JumpScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    static public bool isJump = false;

    private bool isJumping;

    private void Start()
    {
        isJumping = false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || isJumping)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
    }

    /// <summary> While the user press on the jump button, jump is activate. </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        isJumping = true;
    }

    /// <summary> If the user stop to press on the jump button, jump is deactivate. </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        isJumping = false;
    }
}
