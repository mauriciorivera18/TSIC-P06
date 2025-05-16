using System.Collections;
using UnityEngine;

public class destroyMine : MonoBehaviour
{
    public GameObject ptc_exp;

    public float explosionDuration;

    public void hit()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(ExplosionRutine());
    }
    IEnumerator ExplosionRutine()
    {
        float t = 0;
        ptc_exp.SetActive(true);
        while (t < explosionDuration)
        {
            t += Time.deltaTime;
            yield return null;
        }
        ptc_exp.SetActive(false);
        Destroy(this.gameObject);
    }
}
