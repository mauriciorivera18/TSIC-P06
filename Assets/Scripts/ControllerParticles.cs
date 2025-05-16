using UnityEngine;

public class ControllerParticles : MonoBehaviour
{
    [SerializeField] GameObject particulas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag=="Ground")
        {
            particulas.SetActive(false);
            print("Tocando el suelo");
        }
    }

    void OnCollisionExit(Collision col)
    {
          if(col.transform.tag=="Ground")
        {
            particulas.SetActive(true);
             print("Saliendo");
        }
    }
}
