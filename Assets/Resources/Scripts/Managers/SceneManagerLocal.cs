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

    private void Awake()
    {
   
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
        SceneManagerStatic.LoadNScene(sceneIndex);

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
        ChangeScene(0);
    }

    public void ToMainGame()
    {
        ChangeScene(1);
    }

    public void ToOutro()
    {
    }

    //special transitions:

    public void Reload()
    {

        SceneManagerStatic.ReloadScene();


        Debug.Log("Loading screen scene index is " + SceneManager.GetActiveScene().buildIndex);
     

        IEnumerator SpecialDelayRoutine(float delayDuration, int sceneIndex)
        {
            Debug.Log("Coroutine entry");
            yield return new WaitForSeconds(delayDuration);
            Debug.Log("Coroutine Exit");
            SceneManagerStatic.ReloadScene();
        }

    }


    public void LoadNextLevel()
    {
        Debug.Log("Loading screen scene index is " + (SceneManager.GetActiveScene().buildIndex + 1));
        SceneManagerStatic.LoadNextScene();


        IEnumerator SpecialDelayRoutine2(float delayDuration)
        {
            Debug.Log("Coroutine entry");
            yield return new WaitForSeconds(delayDuration);
            Debug.Log("Coroutine Exit");
            SceneManagerStatic.LoadNextScene();
        }
    }

    public void Quit()
    {
        SceneManagerStatic.GameQuit();
        /*
        IEnumerator SpecialDelayRoutine3(float delayDuration)
        {
            Debug.Log("Coroutine entry");
            yield return new WaitForSeconds(delayDuration);
            Debug.Log("Coroutine Exit");
            SceneManagerStatic.GameQuit();
        }

        Cursor.lockState = CursorLockMode.Locked;
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
    */
    }


}
