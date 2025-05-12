using UnityEngine;

public class destroyBomb : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
