using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script changes the scenes after any sound effects have concluded playing. 
//It could be expanded to include managing animations during scene transitions.
public class SceneManagerLocal : MonoBehaviour
{
    AudioManagerSoundEffects audioManagerSoundEffects;
    AudioManagerAmbientMusic audioManagerAmbient;
    GameStateManager gameStateManager;

    float delayDuration;

    public int introSceneIndex = 0;
    public int tutorialSceneIndex = 1;
    public int mainSceneIndex = 3;
    public int outroSceneIndex;
    public int currentSceneIndex;
    public int reloadCode  = 12;
    public int quitCode = 13;
    
    private void Awake()
    {
        //needs to be computed during runtime:
        outroSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Sets the default state of the cursor, because in case a player returns to this screen from 3d mode, the cursor will still be locked!
        Cursor.lockState = CursorLockMode.None;
        //only one of these in every scene:
        audioManagerSoundEffects = FindObjectOfType<AudioManagerSoundEffects>();
        audioManagerAmbient = FindObjectOfType<AudioManagerAmbientMusic>();
        gameStateManager = FindObjectOfType<GameStateManager>();
        if (gameStateManager != null)
        {
            //gameStateManager.UnPauseGame(); 
        }

    }

    //base method:
    void ChangeScene(int sceneIndex)
    {
        Debug.Log("Loading scene with Index " + sceneIndex);
        //no more buttons clicked after this:
        Cursor.lockState = CursorLockMode.Locked;
        //have the music stop before the sound effect starts!
        audioManagerAmbient.FadeOutSound(0.5f);
        //start the sound effect and get its duration to the variable delayDuration ('SceneSwitchSoundEffect' returns float)
        AudioClip pertinentAudioClip;
        if (audioManagerSoundEffects.sceneToSoundMatch.TryGetValue(sceneIndex, out pertinentAudioClip))
        {
            audioManagerSoundEffects.SceneSwitchSoundEffect(sceneIndex);
            delayDuration = pertinentAudioClip.length;
            Debug.Log("delayDuration" + delayDuration);
        }
        else
        {
            delayDuration = 0.5f;
            Debug.Log("delayDuration" + delayDuration);
        }
        StartCoroutine(DelayCoroutine(delayDuration, sceneIndex));
    }

    IEnumerator DelayCoroutine(float delayDuration, int sceneIndex)
    {
        if (gameStateManager != null)
        { 
        //    gameStateManager.UnPauseGame(); 
        }
        Debug.Log("Coroutine entry " + Time.time);
        yield return new WaitForSeconds(delayDuration);
        Debug.Log("Coroutine Exit" + Time.time);
        SceneManagerStatic.LoadNScene(sceneIndex);
   }


    //All these are public because they are called from button clicks of the UI!
    public void ToIntro()
    {
        ChangeScene(introSceneIndex);
    }

    public void ToTutorialIntro()
    {
        ChangeScene(tutorialSceneIndex);
    }

    public void ToTutorialGamePlay()
    {
        SceneManagerStatic.LoadNextScene();
    }

    public void ToMainGame()
    {
        ChangeScene(mainSceneIndex);
    }

    public void ToOutro()
    {
        Debug.Log("outroSceneIndex is " + outroSceneIndex);
        ChangeScene(outroSceneIndex);
    }

    //special transitions:

    public void Reload()
    {
        Debug.Log("Loading screen scene index is " + currentSceneIndex);
        IEnumerator SpecialDelayRoutine(float delayDuration, int sceneIndex)
        {
            Debug.Log("Coroutine entry");
            yield return new WaitForSeconds(delayDuration);
            Debug.Log("Coroutine Exit");
            SceneManagerStatic.ReloadScene();
        }


        //same code with previous: 
        //no more buttons clicked after this:
        Cursor.lockState = CursorLockMode.Locked;
        //have the music stop before the sound effect starts!
        audioManagerAmbient.FadeOutSound(0.5f);

        //start the sound effect and get its duration to the variable delayDuration ('SceneSwitchSoundEffect' returns float)
        AudioClip pertinentAudioClip;
        if (audioManagerSoundEffects.sceneToSoundMatch.TryGetValue(reloadCode, out pertinentAudioClip))
        {
            delayDuration = pertinentAudioClip.length;
            audioManagerSoundEffects.SceneSwitchSoundEffect(reloadCode);
            Debug.Log("delayDuration" + delayDuration);
        }
        else
        {
            delayDuration = 0.5f;
            Debug.Log("delayDuration" + delayDuration);
        }
        StartCoroutine(SpecialDelayRoutine(delayDuration, currentSceneIndex));
    }


    public void LoadNextLevel()
    {
        Debug.Log("Loading screen scene index is " + currentSceneIndex + 1 );
        IEnumerator SpecialDelayRoutine2(float delayDuration)
        {
            Debug.Log("Coroutine entry");
            yield return new WaitForSeconds(delayDuration);
            Debug.Log("Coroutine Exit");
            SceneManagerStatic.LoadNextScene();
        }

        //same code with previous: 
        //no more buttons clicked after this:
        Cursor.lockState = CursorLockMode.Locked;
        //have the music stop before the sound effect starts!
        audioManagerAmbient.FadeOutSound(0.5f);

        //start the sound effect and get its duration to the variable delayDuration ('SceneSwitchSoundEffect' returns float)
        AudioClip pertinentAudioClip;
        if (audioManagerSoundEffects.sceneToSoundMatch.TryGetValue(reloadCode, out pertinentAudioClip))
        {
            delayDuration = pertinentAudioClip.length;
            audioManagerSoundEffects.SceneSwitchSoundEffect(reloadCode);
            Debug.Log("delayDuration" + delayDuration);
        }
        else
        {
            delayDuration = 0.5f;
            Debug.Log("delayDuration" + delayDuration);
        }
        StartCoroutine(SpecialDelayRoutine2(delayDuration));
    }

    public void Quit()
    {
        IEnumerator SpecialDelayRoutine3(float delayDuration)
        {
            Debug.Log("Coroutine entry");
            yield return new WaitForSeconds(delayDuration);
            Debug.Log("Coroutine Exit");
            SceneManagerStatic.GameQuit();
        }

        //same code with previous: 
        //no more buttons clicked after this:
        Cursor.lockState = CursorLockMode.Locked;
        //have the music stop before the sound effect starts!
        audioManagerAmbient.FadeOutSound(0.5f);

        //start the sound effect and get its duration to the variable delayDuration ('SceneSwitchSoundEffect' returns float)
        AudioClip pertinentAudioClip;
        if (audioManagerSoundEffects.sceneToSoundMatch.TryGetValue(quitCode, out pertinentAudioClip))
        {
            delayDuration = pertinentAudioClip.length;
            audioManagerSoundEffects.SceneSwitchSoundEffect(quitCode);
            Debug.Log("delayDuration" + delayDuration);
        }
        else
        {
            delayDuration = 0.5f;
            Debug.Log("delayDuration" + delayDuration);
        }
        StartCoroutine(SpecialDelayRoutine3(delayDuration));

    }

}
