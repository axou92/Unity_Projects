using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Move the player
    FixedJoystick MoveJoystick;

    // Win or loose 
    public GameObject completeLevelUI;
    public GameObject loseUI;
    public GameObject gameUI;

    // Change player's parameter
    public float speed = 5;
    public float jump = 8;

    Rigidbody rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // Destroy the player
    public GameObject player;
    public SphereCollider col;
    public GameObject pieces;
    public GameObject wholeBall;

    public GameObject family;

    bool isDestroyed = false;
    bool isJoint = false; // joint between the player and other objects
    int colision = 1;

    // Wait function
    float timer = 0;
    float timerMax = 0;
    private bool Waited(float seconds)
    {
        timerMax = seconds;
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            return true;
        }
        return false;
    }

    void Awake()
    {
        MoveJoystick = FindObjectOfType<FixedJoystick>();
        rb = GetComponent<Rigidbody>();
        JumpScript.isJump = false;
    }

    void Update()
    {
        if((MoveJoystick.Horizontal!=0) || (MoveJoystick.Vertical != 0))
        {
            rb.velocity = new Vector3(speed * MoveJoystick.Horizontal * 2f, rb.velocity.y, speed * MoveJoystick.Vertical * 2f);
        }

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
            youLoose();
        }
    }

    public void levelComplete()
    {
        PauseMenu.gameIsPaused = true;
        Manager.actualTime = 0;
        gameUI.SetActive(false);
        completeLevelUI.SetActive(true);        
    }

    public void youLoose()
    {
        PauseMenu.gameIsPaused = true;
        isDestroyed = true;

        wholeBall.SetActive(false);
        pieces.SetActive(true);
        rb.isKinematic = true;
        col.enabled = false;

        // Wait 2 seconds before to set the time to 0 and display the lose UI
        if (!Waited(4 / colision)) return; // Time divided by 2 if it's because of time 
        gameUI.SetActive(false);
        loseUI.SetActive(true);
    }

    void OnCollisionEnter(Collision colInfo)
    {
        // Colision whch kill the player
        if (colInfo.gameObject.tag == "DANGER")
        {
            colision = 2;
            youLoose();
        }

        if (colInfo.gameObject.tag == "WIN")
        {
            levelComplete();
        }

        if (colInfo.gameObject.tag == "LOSE")
        {
            youLoose();
        }

        if(colInfo.gameObject.tag == "Platform")
        {
            //JumpScript.isJump = false;
            //Debug.Log(wholeBall.transform.parent);

            //colInfo.gameObject.transform.parent = family.transform;
            //player.transform.parent = family.transform;

        }

        // Colision for jump Higher or speed(for instance)
    }
}
