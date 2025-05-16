using System.Collections;
using UnityEngine;

public class destroyBomb : MonoBehaviour
{
    public UIManager planescore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Ground")
        {
            StartCoroutine(GroundedBombRoutine());
        }

        if(col.transform.tag == "pillmine")
        {
            col.gameObject.GetComponent<destroyMine>().hit();
            Destroy(this.gameObject);
        }
    }

    IEnumerator GroundedBombRoutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
