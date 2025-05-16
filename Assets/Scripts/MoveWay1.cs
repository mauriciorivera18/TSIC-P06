using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWay1 : MonoBehaviour
{
    public WayCreator1[] pathFollow;
    public MoveWay planeStatus;
    public int currentWayPointID;
    public float rotSpeed;
    public float speed;
    
    public float reachDistance=0.1f;
    public int way=0;

    Vector3 last_position;
    Vector3 current_position;

    // Start is called before the first frame update
    void Start()
    {
        last_position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance=Vector3.Distance(pathFollow[way].path_objs[currentWayPointID].position,transform.position);
        transform.position=Vector3.MoveTowards (transform.position,pathFollow[way].path_objs[currentWayPointID].position,Time.deltaTime*speed);
        transform.rotation=Quaternion.RotateTowards(transform.rotation, pathFollow[way].path_objs[currentWayPointID].rotation, Time.deltaTime * speed);
        if (distance<=reachDistance)
        {
            currentWayPointID=1;
        }

        if (planeStatus.falling)
        {
            currentWayPointID = 2;
            speed = 90.0f;
        }
    }
}
