using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlaneGame1 : MonoBehaviour
{
    public MoveWay movement;

    private bool isWobbling = false;
    private Quaternion originalRotation;
    private int touchCount = 0;

    //GAMEOBJECTS de particulas
    public GameObject ptc_smoke;
    public GameObject ptc_exp;

    //Colores para el Dissolve
    public Color dissolveStartColor;
    public Color dissolveEndColor;

    public float explosionDuration;
    public float dissolveDuration;

    void Start()
    {
        originalRotation = transform.localRotation;

        if (movement == null)
            movement = GetComponent<MoveWay>();
    }

    void OnMouseDown()
    {
       touchCount++;

       if (!isWobbling)
        {
            StartCoroutine(WobbleAndSpeedUp());
        }

        if (touchCount == 3)
        {
            movement.speed = 30.0f;
            movement.falling = true;
            ptc_smoke.SetActive(false);
            StartCoroutine(ExplosionRutine());
            StartCoroutine(DissolveRutine());
        }
    }

    IEnumerator WobbleAndSpeedUp()
    {
        isWobbling = true;
        movement.speed *= 2.0f;

        float t = 0f;

        while (t < 50.0f/movement.speed)
        {
            float angle = Mathf.Sin(Time.time * 20f) * 30f;
            transform.localRotation = originalRotation * Quaternion.Euler(0f, angle, 0f);
            t += Time.deltaTime;
            yield return null;
        }

        t = 0f;
        Quaternion currentRot = transform.localRotation;
        while (t < 1f)
        {
            transform.localRotation = Quaternion.Slerp(currentRot, originalRotation, t);
            t += Time.deltaTime * 2f;
            yield return null;
        }
        isWobbling = false;
    }

    IEnumerator ExplosionRutine(){
        float t = 0;
        ptc_exp.SetActive(true);
        while(t<explosionDuration){
            t+= Time.deltaTime;
            yield return null;
        }
        ptc_exp.SetActive(false);
    }

    IEnumerator DissolveRutine(){
        float t = 0;
        float phase;
        Material matediss = GetComponent<Renderer>().material;
        Color disscolor;

        while(t<dissolveDuration){
            t+= Time.deltaTime;
            phase = Mathf.Lerp(0,1,t/dissolveDuration);
            
            matediss.SetFloat("_DissolveStrength",phase);
            disscolor = Color.Lerp(dissolveStartColor,dissolveEndColor,phase);
            matediss.SetColor("_Color", disscolor);

            yield return null;
        }
    }
}