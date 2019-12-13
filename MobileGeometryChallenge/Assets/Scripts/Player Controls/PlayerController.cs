using UnityEngine;

/// <summary>
/// This script allows to move the player ball and must be put on it. 
/// Arrow and space key board can be use for debugging the application.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// Public variables.
    [Header("Canvas")]
    public GameObject completeLevelUI;
    public GameObject loseUI;
    public GameObject gameUI;

    [Header("Player's parameters")]
    public float speed = 8;
    public float decelleration = 4;
    public float jump = 8;
    public float distGround = 0.5f;

    [Header("Destroy the player")]
    public SphereCollider col;
    public GameObject pieces;
    public GameObject wholeBall;

    /// Private variables.
    private FixedJoystick MoveJoystick;
    private Rigidbody rb;
    private bool isDestroyed = false;
    private int colision = 1;
    private float timer = 0;

    void Start()
    {
        MoveJoystick = FindObjectOfType<FixedJoystick>();
        rb = GetComponent<Rigidbody>();
        Collider playerCol = gameObject.GetComponent<SphereCollider>();
        distGround = playerCol.bounds.extents.y;
    }

    void Update()
    {
        float x = 0.0f;
        float y = 0.0f;
        float z = 0.0f;

        if (IsGrounded())
        {
            if (((MoveJoystick.Horizontal != 0) || (MoveJoystick.Vertical != 0)))
            {
                x = MoveJoystick.Horizontal * 2 * speed;
                z = MoveJoystick.Vertical * 2 * speed;
            }
            else
            {
                x = -rb.velocity.x * decelleration;
                z = -rb.velocity.z * decelleration;
            }
        }
        if ((JumpScript.isJump && rb.velocity.y == 0))
        {
            y = jump;
            rb.AddForce(0, y, 0, ForceMode.Impulse);
        }

        if (rb.velocity.x > speed)
        {
            rb.AddForce(0, y, z);
        }
        else if(rb.velocity.z > speed)
        {
            rb.AddForce(x, y, 0);
        }
        else
        {
            rb.AddForce(x, y, z);
        }

        if (isDestroyed)
        {
            YouLoose();
        }
    }

    /// ------------------------------ Public functions ------------------------------

    /// <summary> Display the Win UI when the level is complete. </summary>
    public void LevelComplete()
    {
        PauseMenu.gameIsPaused = true;
        Manager.manager.actualTime = 0;
        gameUI.SetActive(false);
        completeLevelUI.SetActive(true);
    }

    /// <summary> Display the Lose UI when the time is over or the ball is destroyed. </summary>
    public void YouLoose()
    {
        PauseMenu.gameIsPaused = true;
        isDestroyed = true;

        wholeBall.SetActive(false);
        pieces.SetActive(true);
        rb.isKinematic = true;
        col.enabled = false;

        /// Wait 2 seconds before to set the time to 0 and display the lose UI
        if (!Waited(4 / colision)) return;
        gameUI.SetActive(false);
        loseUI.SetActive(true);
    }

    /// ------------------------------ Private functions ------------------------------

    /// <summary>Detect if the player is on the ground. </summary>
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distGround + 0.1f);
    }

    /// <summary> Wait a specific time defined by the user. </summary>
    /// <param name="seconds"> Time to wait in seconds. </param>
    /// <returns> Return true if the waiting time is over. </returns>
    private bool Waited(float seconds)
    {
        timer += Time.deltaTime;
        if (timer >= seconds)
        {
            return true;
        }
        return false;
    }

    /// <summary> Regroup all the collision event. </summary>
    /// <param name="colInfo"> Gameobject which the player enter in collision. </param>
    private void OnCollisionEnter(Collision colInfo)
    {
        /// Case where the ball is in contact with a kill obstacle.
        if (colInfo.gameObject.CompareTag("DANGER"))
        {
            colision = 2;
            YouLoose();
        }

        /// Case where the ball is in contact with a win area.
        if (colInfo.gameObject.CompareTag("WIN"))
        {
            LevelComplete();
        }

        /// Case where the ball is in contact with a lose area.
        if (colInfo.gameObject.CompareTag("LOSE"))
        {
            YouLoose();
        }

        /// Case where the ball is in contact with a jump boost.
        if (colInfo.gameObject.CompareTag("JumpBoost"))
        {

        }

        /// Case where the ball is in contact with a speed boost.
        if (colInfo.gameObject.CompareTag("SpeedBoost"))
        {

        }
    }
}
