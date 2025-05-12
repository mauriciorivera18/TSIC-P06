using System;
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
            GameObject inst=Instantiate(bomb, positionBomb.position, Quaternion.identity);
            Rigidbody rb = inst.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.down * 10000f, ForceMode.Acceleration);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
          score += 1;
        }
    }
}
