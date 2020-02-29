using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour
{

    MovementController movementController;

    AudioSource audioSource;

    public AudioClip walkingSound;
    public AudioClip runningSound;
    public AudioClip jumpingSound;
    public AudioClip levitatingSound;
    public AudioClip flappingSound;

    public float fadeDuration;
    public float switchDuration;



    void Start()
    {
        movementController = GetComponentInParent<MovementController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementSoundEffect();
    }




    void MovementSoundEffect()
    {
        if (movementController.isLevitating)
        {
            if (!audioSource.isPlaying)
            {
                if (audioSource.clip != levitatingSound)
                {
                    audioSource.clip = levitatingSound;
                }
                    { FadeInSound(fadeDuration); }
                }
            }

            else if (movementController.isWalking)
            {
                if (audioSource.clip != walkingSound)
                {
                    audioSource.clip = walkingSound;
                }
                if (!audioSource.isPlaying)
                {
                    { FadeInSound(fadeDuration); }
                }
            }

            else if (movementController.isRunning)
            {

                if (audioSource.clip != runningSound)
                {
                    audioSource.clip = runningSound;
                }
                if (!audioSource.isPlaying)
                {
                    { FadeInSound(fadeDuration); }
                }
            }


            else if (audioSource.isPlaying)
            {
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

        IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
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

        IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
        {

            float startVolume = audioSource.volume;
            float endVolume = 1f;
            float amount = endVolume - startVolume;
            float amountPerSeconds = amount / fadeTime;
            float amountPerFrame = amountPerSeconds * Time.deltaTime;

            audioSource.Play();

            while (audioSource.volume < endVolume)
            {
                audioSource.volume += amountPerFrame;

                yield return null;
            }

            audioSource.volume = 1f;
            currentCoroutine = null;
        }


        IEnumerator SwitchSoundWithFadeOut(AudioSource audioSource, float fadeTime, AudioClip newClip)
        {
            float startVolume = audioSource.volume;
            float endVolume = 0f;
            float amount = startVolume - endVolume;
            float amountPerSeconds = amount / fadeTime;
            float amountPerFrame = amountPerSeconds * Time.deltaTime;

            while (audioSource.volume > endVolume)
            {
                audioSource.volume -= amountPerFrame;
                yield return null;
            }

            audioSource.clip = newClip;
            audioSource.volume = 1f;
            currentCoroutine = null;
        }

    }
