using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//this script controls the sound effects in all scenes. 
//It is used to play sound effects of gameElements, especially items instantly destroyed before they get to play the audio in their own audiosource.
//Since in 2D mode the spatial origin of the sound's don't matter, this 'hub' is a good substitute.
    
//Additionally, the GameObject of this script plays specific effects related to events and scene transitions.
//Some of these could be relocated to their respective buttons, but they are gathered here for now for overview purposes.

[RequireComponent(typeof(AudioSource))]
public class AudioManagerSoundEffects : MonoBehaviour
{
    //these are all sound-effects that are triggered to play. Assign them by hand in the editor. .


    //for gameplay events:
    public AudioClip playerDeath;
    public AudioClip gameWon;
    public AudioClip gameLost;

    //for scene transitions:

    //used for home/intro screen
    public AudioClip gameStart;
    //used for loading tutorial and main screens
    public AudioClip gamePlay;
    //used for loading outro scene
    public AudioClip gameExit;

    //special scene transitions:

    //used for quiting the application:
    public AudioClip gameQuit;
    //used for reloading whatever the current scene is
    public AudioClip gameReload;

    AudioSource audioSource;
    public AudioMixerGroup audioMixerGroupMusic;

    public Slider slider;
 
    GameStateManager gameStateManager;
       
    SceneManagerLocal sceneManagerLocal;

    private void Awake()
    {
        //no checks if null, since there is the 'require' attribute on the class
        audioSource = GetComponent<AudioSource>();

        //this is to accomodate an expansion feature with fade in and out effects on sound using Mixers. 
        audioSource.outputAudioMixerGroup = audioMixerGroupMusic;

        Slider[] allSliders = FindObjectsOfType<Slider>();
        foreach (Slider thisSlider in allSliders)
        {
            if (thisSlider.gameObject.name == "SliderEffects")
                slider = thisSlider;
        }


        //there is only one of these:
        gameStateManager = FindObjectOfType<GameStateManager>();
        //subscribe methods to events:
        if (gameStateManager != null)
        { 
        //gameStateManager.gameWonEvent += GameWonSoundEffect;
      //  gameStateManager.gameLostEvent += GameLostSoundEffect;
        }

        sceneManagerLocal = FindObjectOfType<SceneManagerLocal>();
    }

    private void Start()
    {

    }


    //This is to set the volume directly from the slider
    public void SetVolume()
    {
        audioSource.volume = slider.value;
    }

    //plays  one time whatever audio file has been assigned to the variable, with priority over previous sound. 
    public void PlaySoundEffect(AudioClip audioClip)
    {
        if (audioSource.isPlaying)
        {
            //change stop with a very fast fade-out
            audioSource.Stop();
        }
        audioSource.PlayOneShot(audioClip);
    }



    //for events!
    void GameWonSoundEffect()
    {
        PlaySoundEffect(gameWon);
    }

    void GameLostSoundEffect()
    {
        PlaySoundEffect(gameLost);
    }

    void PlayerDeathSoundEffect()
    {
        PlaySoundEffect(playerDeath);
    }

}
