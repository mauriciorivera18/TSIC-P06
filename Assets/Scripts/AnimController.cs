using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator animController;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public string[] nameClips;


    public int countBaile = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animController = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorClipInfo[] animatorClips = animController.GetCurrentAnimatorClipInfo(0);

    
    }
    public void ManejaBaile(int numero)
    {

        for (int i = 0; i < nameClips.Length; i++)
        {
            animController.SetBool(nameClips[i], false);
        }

        if (numero < audioClips.Length)
            audioSource.clip = audioClips[numero];
        animController.SetBool(nameClips[numero], true);
        if (!audioSource.isPlaying)
            audioSource.Play();

    }

    public void NoDance()
    {
        audioSource.Stop();
        animController.SetBool(nameClips[2], true);
     
    }

}



