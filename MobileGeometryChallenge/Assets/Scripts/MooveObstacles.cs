using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooveObstacles : MonoBehaviour {

    // public GameObject killObstacle;
    public float startTime;
    public float maxX;
    public float maxY;
    public float maxZ;
    public float speed;

    float x;
    float y;
    float z;
    bool limit = false;

    void Start ()
    {
        x = transform.position.x + maxX;
        y = transform.position.y + maxY;
        z = transform.position.z + maxZ;
    }
	
	void Update ()
    {
        float newX = 0;
        float newY = 0;
        float newZ = 0;

        Debug.Log(y - transform.position.y);
        Debug.Log(limit);
        if(Time.time > startTime)
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
