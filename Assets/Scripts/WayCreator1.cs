using System.Collections.Generic;
using UnityEngine;

public class WayCreator1 : MonoBehaviour
{
    public Color lineColor = Color.white;
    public float sizePoints = 0.01f;

    public List<Transform> path_objs = new List<Transform>();
    public Transform[] pointsArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        pointsArray = GetComponentsInChildren<Transform>();
        path_objs.Clear();
        foreach (Transform path_obj in pointsArray)
        {
            if (path_obj != this.transform)
            {
                path_objs.Add(path_obj);
            }
        }


        for (int i = 0; i < path_objs.Count; i++)
        {
            Vector3 position = path_objs[i].position;
            Gizmos.DrawWireSphere(position, sizePoints);

            if (i > 0)
            {
                Gizmos.DrawLine(path_objs[i - 1].position, position);
            }
        }
    }
}
