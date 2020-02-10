using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//this script is not loaded to any gameObject. It does not derive from Monobehaviour and answers no calls from Unity engine. 
//The methods are not specific to a particular project and are thus reuseable.
//Scripts such as these are used as tiny, reusable 'libraries' in different projects and then, a Monobehaviour script is used to call these functions during runtime.

public static class SceneManagerStatic 
{
    public static void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("currentIndex: " + currentIndex);
        int nextIndex = currentIndex +1;
        Debug.Log("nextIndex: " + nextIndex);
        if (ErrorCheckIndex(nextIndex))
        { 
            SceneManager.LoadScene(nextIndex);
        }
        else
        { 
            Debug.Log("Invalid index"); 
        }

    }

    public static bool ErrorCheckIndex(float index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        return true;
        else
        return false;
    }

    public static void LoadNScene(int n)
    {
        if (ErrorCheckIndex(n))
        {
            SceneManager.LoadScene(n);
        }
        else
        {
            Debug.Log("Invalid index");
        }
    }

    public static void LoadLastScene()
    {
        int highestIndex = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(highestIndex);
    }

    public static void ReloadScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public static void GameQuit()
    {
        Application.Quit();
    }
 
}
