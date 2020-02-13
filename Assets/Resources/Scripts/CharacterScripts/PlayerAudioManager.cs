using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour
{

    FPMovement fPMovement;    // Use this for initialization
    AudioSource audioSource;
    public AudioClip walkingSound;
    public AudioClip runningSound;
    public AudioClip jumpingSound;


    void Start()
    {
        fPMovement = GetComponent<FPMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkingSoundEffect();
        //RunningSoundEffect();
    }

    void WalkingSoundEffect()
    {
        if (fPMovement.isWalking)
        {
            if (audioSource.clip != walkingSound)
            {
                audioSource.clip = walkingSound;
            }
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
         
                //audioSource.PlayOneShot(walkingSound);
        else if (fPMovement.isRunning)
        {

            if (audioSource.clip != runningSound)
            {
                audioSource.clip = runningSound;
            }
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }

        else 
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
    
    }


    public void PlayOnceatJump()
    { 
    
    }

}
