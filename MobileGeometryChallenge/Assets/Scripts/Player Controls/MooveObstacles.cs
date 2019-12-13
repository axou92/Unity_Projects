using UnityEngine;

/// <summary> Allows to moove obstacle inside of the game. </summary>
public class MooveObstacles : MonoBehaviour
{
    [Header("Obstacles properties")]
    public float maxX;
    public float maxY;
    public float maxZ;
    public float speed;
    public bool objectCanMoove;

    /// Private variables.
    private float x;
    private float y;
    private float z;
    private bool limit;

    private void Start ()
    {
        x = transform.position.x + maxX;
        y = transform.position.y + maxY;
        z = transform.position.z + maxZ;
        limit = false;
    }
	
	private void Update ()
    {
        UpdateObstaclePosition();
    }

    /// <summary> Update the new position of the obstacle. </summary>
    private void UpdateObstaclePosition()
    {
        if (objectCanMoove)
        {
            if ((x - transform.position.x == 0) && (y - transform.position.y == 0) && (z - transform.position.z == 0))
            {
                limit = true;
            }
            else if ((x - transform.position.x == maxX) && (y - transform.position.y == maxY) && (z - transform.position.z == maxZ))
            {
                limit = false;
            }

            float newX;
            float newY;
            float newZ;
            if (((x - transform.position.x != 0) || (y - transform.position.y != 0) || (z - transform.position.z != 0)) && limit == false)
            {
                newX = x;
                newY = y;
                newZ = z;
            }
            else
            {
                newX = x - maxX;
                newY = y - maxY;
                newZ = z - maxZ;
            }

            Vector3 endPosition = new Vector3(newX, newY, newZ);

            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
    }

    /// <summary> Detect if the player enter on the collider to activate the platform or a trap. </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objectCanMoove = true;
            other.transform.parent = transform;            
        }
    }

    /// <summary> Detect if the player it is not on the collider. </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Platform"))
        {
            if (!JumpScript.isJump)
            {
                objectCanMoove = false;
            }
            other.transform.parent = null;
        }
    }
}
