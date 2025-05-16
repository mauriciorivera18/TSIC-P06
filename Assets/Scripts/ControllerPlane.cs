using System;
using TMPro;
using UnityEngine;

public class ControllerPlane : MonoBehaviour
{
    public GameObject bomb;
    public Transform positionBomb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject inst=Instantiate(bomb, positionBomb.position, Quaternion.identity);
            Rigidbody rb = inst.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.down * 10000f, ForceMode.Acceleration);
        }
    }
}
