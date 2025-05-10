using UnityEngine;

public class ControllerPlane : MonoBehaviour
{
    public GameObject bomb;
    public MoveWay moveWay;

    public Transform positionBomb;

    public Animator animator;

    public int score = 0;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.transform.tag == "Player")
                {
                    print("Tocando el avion");
                    moveWay.speed += 0.5f;
                    animator.SetTrigger("activaTambaleo");
                }
            }
        }

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
