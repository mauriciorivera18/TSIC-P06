using System.Collections.Generic;
using UnityEngine;

public class WayCreator2 : MonoBehaviour
{
    public Color lineColor = Color.white;
    public float sizePoints = 0.01f;

    public Vector2 xOffsetRange = new Vector2(-150f, 150f);
    public Vector2 yOffsetRange = new Vector2(-30f, 30f);
    public Vector2 zOffsetRange = new Vector2(0f, 300f);

    public List<Transform> path_objs = new List<Transform>();
    public Transform[] pointsArray;
    public bool offsetsApplied = false;

    private void Update()
    {
        if (!offsetsApplied)
        {
            ApplyOffsetToPoints();
            offsetsApplied = true;
        }
    }

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

        // Solo aplicar offset una vez
        if (!offsetsApplied)
        {
            ApplyOffsetToPoints();
            offsetsApplied = true;
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

    private void ApplyOffsetToPoints()
    {
        foreach (Transform path_obj in path_objs)
        {
            //path_obj.position = new Vector3(0.0f, 120.0f, 200.0f);
            if (path_objs.IndexOf(path_obj)==0)
            {
                continue;
            }
            path_obj.position = new Vector3(0.0f, 120.0f, 200.0f);
            Vector3 offset = new Vector3(
                Random.Range(xOffsetRange.x, xOffsetRange.y),
                Random.Range(yOffsetRange.x, yOffsetRange.y),
                Random.Range(zOffsetRange.x, zOffsetRange.y)
            );
            path_obj.position += offset;
            if (path_objs.IndexOf(path_obj) == 4)
            {
                path_obj.position = new Vector3(path_obj.position.x, 0.0f, path_obj.position.z);
            }
        }
    }
}
