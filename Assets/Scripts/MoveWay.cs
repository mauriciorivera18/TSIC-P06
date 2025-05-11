using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveWay : MonoBehaviour
{
    public WayCreator[] pathFollow;
    public int currentWayPointID;
    public float rotSpeed;
    public float speed;
    public bool falling=false;
    public bool actExplosion=false;
    public bool endJourney = false;
    public float reachDistance=0.1f;

    public int way=0;

    Vector3 last_position;
    Vector3 current_position;

    // Start is called before the first frame update
    void Start()
    {
        last_position =transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.touchCount>1)
        { 
            way=1;
            currentWayPointID=0;
            speed=0.7f;
        }

        float distance = Vector3.Distance(pathFollow[way].path_objs[currentWayPointID].position, transform.position);
        var Rotation = Quaternion.LookRotation((pathFollow[way].path_objs[currentWayPointID].position - transform.position).normalized);

        if (!falling)
        {
            transform.position = Vector3.MoveTowards(transform.position, pathFollow[way].path_objs[currentWayPointID].position, Time.deltaTime * speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Rotation * Quaternion.Euler(-90, 0, 0), Time.deltaTime * rotSpeed);
        }

        if(distance<=reachDistance)
        {
            currentWayPointID++;
        }

        if(currentWayPointID>=pathFollow[way].path_objs.Count-1)
        {
            currentWayPointID=1;
            if(way==1)
            {
                way=0;
                speed=0.2f;
            }
            pathFollow[way].offsetsApplied = false;
        }

        if (falling)
        {
            currentWayPointID = pathFollow[way].path_objs.Count - 1;
            pathFollow[way].offsetsApplied = true;
            Quaternion Fall = transform.rotation;
            Fall.x = 0.0f;
            Vector3 currentpos = transform.position;
            currentpos.y = 0.0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, Fall,rotSpeed*Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, currentpos, Time.deltaTime * speed);
            endJourney = true;
        }

        if (transform.position.y == 0 && endJourney == true) 
        {
            actExplosion = true;            
        }        
    }
}
