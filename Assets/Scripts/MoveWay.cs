using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWay : MonoBehaviour
{
    public WayCreator[] pathFollow;
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
        var Rotation=Quaternion.LookRotation(pathFollow[way].path_objs[currentWayPointID].position-transform.position);
        transform.rotation=Quaternion.Slerp(transform.rotation,Rotation,Time.deltaTime*rotSpeed);


        if(distance<=reachDistance)
        {
            currentWayPointID++;
        }

        if(currentWayPointID>=pathFollow[way].path_objs.Count)
        {
            way=Random.Range(0,pathFollow.Length);
            currentWayPointID=0;
        }
    }
}
