using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlaneGame : MonoBehaviour
{
    public MoveWay movement;

    private bool isWobbling = false;
    private Quaternion originalRotation;
    private int touchCount = 0;
    public bool inGround = false;

    //GAMEOBJECTS de particulas
    public GameObject ptc_smoke;
    public GameObject ptc_exp;
    public GameObject ptc_black_smoke;
    public GameObject prop;

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

    private void Update()
    {
        if (transform.position.y == 0.0f)
        {
            if (!inGround)
            {
                StartCoroutine(ExplosionRutine());
                inGround = true;
            }
        }
    }

    void OnMouseDown()
    {
        ptc_black_smoke.SetActive(true);
        touchCount++;

        if (!isWobbling && touchCount<3)
        {
            StartCoroutine(WobbleAndSpeedUp());
        }

        if (touchCount == 3)
        {
            movement.speed = 80.0f;
            movement.falling = true;
            StartCoroutine(DissolveRutine());
        }
    }

    IEnumerator WobbleAndSpeedUp()
    {
        isWobbling = true;
        movement.speed *= 2.0f;

        float t = 0f;

        while (t < 50.0f / movement.speed)
        {
            float angle = Mathf.Sin(Time.time * 20f) * movement.speed/5;
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
    }

    IEnumerator DissolveRutine()
    {
        float t = 0;
        float phase;
        Material matediss = GetComponent<Renderer>().material;
        Material propdiss = prop.GetComponent<Renderer>().material;
        Color disscolor;

        while (t < dissolveDuration)
        {
            t += Time.deltaTime;
            phase = Mathf.Lerp(0, 1, t / dissolveDuration);

            matediss.SetFloat("_DissolveStrength", phase);
            disscolor = Color.Lerp(dissolveStartColor, dissolveEndColor, phase);
            matediss.SetColor("_Color", disscolor);

            propdiss.SetFloat("_DissolveStrength", phase);
            disscolor = Color.Lerp(dissolveStartColor, dissolveEndColor, phase);
            propdiss.SetColor("_Color", disscolor);

            yield return null;
        }
    }
}