using UnityEngine;

/// <summary> Allows to moove obstacle inside of the game. </summary>
public class MooveObstacles : MonoBehaviour
{
    [Header("Obstacles properties")]
    public float startTime;
    public float maxX;
    public float maxY;
    public float maxZ;
    public float speed;

    /// Private variables.
    private float x;
    private float y;
    private float z;
    private bool limit = false;

    private void Start ()
    {
        x = transform.position.x + maxX;
        y = transform.position.y + maxY;
        z = transform.position.z + maxZ;
    }
	
	private void Update ()
    {
        UpdateObstaclePosition();
    }

    /// <summary> Update the new position of the obstacle. </summary>
    private void UpdateObstaclePosition()
    {
        float newX = 0;
        float newY = 0;
        float newZ = 0;

        if (Time.time > startTime)
        {
            if ((x - transform.position.x == 0) && (y - transform.position.y == 0) && (z - transform.position.z == 0))
            {
                limit = true;
            }
            else if ((x - transform.position.x == maxX) && (y - transform.position.y == maxY) && (z - transform.position.z == maxZ))
            {
                limit = false;
            }

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
}
