using UnityEngine;

public class ControllerPlane : MonoBehaviour
{
    public GameObject bomb;
    public Transform positionBomb;
    public int score = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, positionBomb.position, Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
          score += 1;
        }
    }
}
