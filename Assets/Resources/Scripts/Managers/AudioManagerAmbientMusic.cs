using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

//this script controls the ambient audio/music in all scenes. 
//It contains some conditional statements to alter behaviour based on SceneIndex.
[RequireComponent(typeof(AudioSource))]
public class AudioManagerAmbientMusic : MonoBehaviour
{
    //to load assets in editor by hand
    public AudioClip gameIntroSong;

    public AudioClip mainSoundtrack;

    //
    public AudioMixerGroup audioMixerGroupMusic;

    //sets and displays volume - ONLY for music!
    public Slider slider;

    //this is to fade IN sound, in seconds. 
    float fadeInDuration = 1.3f;
    float fadeOutDuration = 1.3f;

    //this variable is to control the change of volume via the mouseScrollWheel / keys
    float sensitivity = 0.1f;

    GameStateManager gameStateManager;

    AudioSource audioSource;

    private void Awake()
    {
        //no checks if null, since there is the 'require' attribute on the class
        audioSource = GetComponent<AudioSource>();
        //to minimize working in editor
        audioSource.playOnAwake = false;

        //this is to accomodate an expansion feature with fade in and out effects on sound using Mixers. 
        audioSource.outputAudioMixerGroup = audioMixerGroupMusic;

        Slider[] allSliders = FindObjectsOfType<Slider>();
        foreach (Slider thisSlider in allSliders)
        {
            if (thisSlider.gameObject.name == "SliderAmbient")
                slider = thisSlider; 
        }

        gameStateManager = FindObjectOfType<GameStateManager>();
        if (gameStateManager != null)
        {
            //music should stop playing when game is paused 
            gameStateManager.GamePausedEvent += TogglePause;
            gameStateManager.GameUnPausedEvent += TogglePause;
            //music should fade out when this session closes 
            gameStateManager.GameEndedEvent += FadeOutGameEnd;
            gameStateManager.GameReloadEvent += FadeOutGameEnd;
        }
    }

    void Start()
    {
        //use intro soundtrack for intro screen
        if (SceneManager.GetActiveScene().buildIndex == 0) 
         {   
            audioSource.clip = gameIntroSong;
            FadeInSound(fadeInDuration);
        }
        else
        //same soundtrack for any of the game play scenes
        {
            audioSource.clip = mainSoundtrack;
            FadeInSound(fadeInDuration);
        }
    }

    void Update()
    {
        //allows (removed: mouse wheel) key control of volume
        EnableVolumeControl();
    }

    #region userMethods
    //I am wrapping up the default play method to include a check.
    public void Play()
    {
        if (audioSource.isPlaying != true)
            audioSource.Play();
    }

    //softer stop than default function.
    void StopPlaying()
    {
        FadeOutSound(0.5f);
    }

    //pause if playing and unpause if paused.
    void TogglePause()
    {
        if (audioSource.isPlaying)
        { audioSource.Pause(); }
        else
        { audioSource.UnPause(); }

        }

    //control audio volume with mouse scrollwheel
    public void EnableVolumeControl()
    {
        //this will cause conflict with camera zoom. 
        //ChangeVolume(Input.mouseScrollDelta.y * sensitivity);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Equals))
        {   ChangeVolume(sensitivity);
            Debug.Log("Increased volume by 0.1");
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Minus))
        { ChangeVolume(-sensitivity);
            Debug.Log("Decreased volume by 0.1");
        }
        //reflect change on slider
        slider.value = audioSource.volume;
    }

    //base: change volume by some value
    void ChangeVolume(float value)
    {
        audioSource.volume += value;
    }

    //This is to set the volume directly from the slider
    public void SetVolume()
    {
        audioSource.volume = slider.value;
    }


    #region  FadeEffects
    void FadeInSound(float duration)
    {
        audioSource.Play();
        audioSource.volume = 0;
        StartCoroutine(StartFade(audioSource, duration, 1));
    }

    public void FadeOutSound(float duration)
    {
        StartCoroutine(StartFade(audioSource, duration, 0));
    }

    public void FadeOutGameEnd()
    {
        FadeOutSound(fadeOutDuration);
    }
    IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;

        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

    }

    #endregion

    #endregion

}
