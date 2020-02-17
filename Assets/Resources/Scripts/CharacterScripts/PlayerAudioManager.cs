using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour
{

    FPMovement fPMovement;    // Use this for initialization

    LevitateBehaviour levitateBehaviour;
    
    AudioSource audioSource;

    public AudioClip walkingSound;
    public AudioClip runningSound;
    public AudioClip levitatingSound;

    public float fadeDuration;
    public float switchDuration;

    void Start()
    {
        fPMovement = GetComponentInParent<FPMovement>();
        levitateBehaviour = GetComponentInParent<LevitateBehaviour>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementSoundEffect();

        if (Input.GetKeyDown(KeyCode.I))
        {
           { FadeInSound(fadeDuration); }
        }
    }




    void MovementSoundEffect()
    {
        if (levitateBehaviour.islevitating)
        {
            if (!audioSource.isPlaying)
            {
                if (audioSource.clip != levitatingSound)
                {
                    FadeOutSound(switchDuration);
                    audioSource.clip = levitatingSound;
                }
              
                { FadeInSound(fadeDuration); }
            }
        }

       else  if (fPMovement.isWalking)
        {
            if (audioSource.clip != walkingSound)
            {
                FadeOutSound(switchDuration);
                audioSource.clip = walkingSound;
            }
            if (!audioSource.isPlaying)
            {
                { FadeInSound(fadeDuration); }
            }
        }

        else if (fPMovement.isRunning)
        {

            if (audioSource.clip != runningSound)
            {
                audioSource.clip = runningSound;
            }
            if (!audioSource.isPlaying)
            {
                { FadeInSound(fadeDuration); }
                //audioSource.Play();
            }
        }


            else if (audioSource.isPlaying)
        {
            //  audioSource.Stop();
            { FadeOutSound(fadeDuration); }
        }

    }


     
    Coroutine currentCoroutine = null;

    void FadeInSound(float fadeDuration)
    {
        if (currentCoroutine == null)
        { currentCoroutine = StartCoroutine(FadeIn(audioSource, fadeDuration)); }
    }

    void FadeOutSound(float fadeDuration)
    {
        if (currentCoroutine == null)
        { 
            currentCoroutine = StartCoroutine(FadeOut(audioSource, fadeDuration));
        }
    }

    public  IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0f)
        {
            audioSource.volume -= Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        currentCoroutine = null;
    }

    public  IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {

        float startVolume = audioSource.volume;
        float endVolume = 1f;
        float amount = endVolume - startVolume;
        float amountPerSeconds = amount / fadeTime;
        float amountPerFrame = amountPerSeconds * Time.deltaTime;

        audioSource.Play();
        while (audioSource.volume < 0.9f)
        {
            audioSource.volume += amountPerFrame;

            yield return null;
        }

        audioSource.volume = 1f;
        currentCoroutine = null;
    }


}
