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
    public float speed = 5;
    public float jump = 8;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

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

    void Awake()
    {
        MoveJoystick = FindObjectOfType<FixedJoystick>();
        rb = GetComponent<Rigidbody>();
        JumpScript.isJump = false;
    }

    void Update()
    {
        /// Mobile movement.
        if((MoveJoystick.Horizontal!=0) || (MoveJoystick.Vertical != 0))
        {
            rb.velocity = new Vector3(speed * MoveJoystick.Horizontal * 2f, rb.velocity.y, speed * MoveJoystick.Vertical * 2f);
        }

        /// Computer movement.
        else
        {
            rb.velocity = new Vector3(speed * Input.GetAxis("Horizontal") * 2f, rb.velocity.y, speed * Input.GetAxis("Vertical") * 2f);
        }
            

        if ((JumpScript.isJump && rb.velocity.y == 0)||(Input.GetButtonDown("Jump")))
        {
            rb.velocity = Vector3.up * jump;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !JumpScript.isJump)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if(isDestroyed)
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
        if (colInfo.gameObject.tag == "DANGER")
        {
            colision = 2;
            YouLoose();
        }

        /// Case where the ball is in contact with a win area.
        if (colInfo.gameObject.tag == "WIN")
        {
            LevelComplete();
        }

        /// Case where the ball is in contact with a lose area.
        if (colInfo.gameObject.tag == "LOSE")
        {
            YouLoose();
        }

        /// Case where the ball is join to a mobile platform.
        if(colInfo.gameObject.tag == "Platform")
        {

        }

        /// Case where the ball is in contact with a jump boost.
        if (colInfo.gameObject.tag == "JumpBoost")
        {

        }

        /// Case where the ball is in contact with a speed boost.
        if (colInfo.gameObject.tag == "SpeedBoost")
        {

        }
    }
}
