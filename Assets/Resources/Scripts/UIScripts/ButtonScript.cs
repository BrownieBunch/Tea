using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//This is the general button Script. 
//Another source plays the assigned sound on receive and lose focus. 
//That source also plays an assigned sound effect if the button confirms or cancels a choice. 
//The cursor changes on enter/exit to draw player attention

// All the rest of unique Behaviour is assigned on the Editor.

public class ButtonScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip takesFocus;
    public AudioClip losesFocus;
    public AudioClip confirmOnClick;
    public AudioClip cancelOnClick;

    AudioManagerSoundEffects audioManagerSoundEffects;
    CursorManager cursorManager;

    [SerializeField]
    bool isConfirm;

    public bool showGameObject;
    public bool hidesParentGameObject;
    public GameObject popUpGameObject;
    public GameObject hideGameObject;

    // Start is called before the first frame update
    void Awake()
    {
        audioManagerSoundEffects = FindObjectOfType<AudioManagerSoundEffects>();
        if (audioManagerSoundEffects == null)
        {
            Debug.LogError("Sound Effects Manager not found [ButtonScript].");
        }
        cursorManager = FindObjectOfType<CursorManager>();
        if (cursorManager == null)
        {
            Debug.LogError("CursorManager not found [ButtonScript].");
        }
        //I added this line to check if the game loads faster with direct assignment or not
        if (takesFocus == null || losesFocus == null || confirmOnClick == null || cancelOnClick == null)
        { 
        AudioClip[] soundEffects = Resources.LoadAll<AudioClip>("Audio\\Sounds\\UI SoundEffects\\ButtonSounds");
        takesFocus = soundEffects[0];
        losesFocus = soundEffects[1];
        confirmOnClick = soundEffects[2];
        cancelOnClick = soundEffects[3];
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        audioManagerSoundEffects.PlaySoundEffect(takesFocus);
        cursorManager.SpecialCursor();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        audioManagerSoundEffects.PlaySoundEffect(losesFocus);
        cursorManager.SimpleCursor();
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (isConfirm)
        {
            audioManagerSoundEffects.PlaySoundEffect(confirmOnClick);
        }
        else
        {
            audioManagerSoundEffects.PlaySoundEffect(cancelOnClick);
        }

        if (showGameObject)
        {
            ShowPopUp();
        }
        else if (hidesParentGameObject)
        {
            HideParentGameObject();
        }
    }

    void ShowPopUp()
    {
        popUpGameObject.SetActive(true);
    }
    void HideParentGameObject()
    {
        hideGameObject.SetActive(false);
        //this.transform.parent.gameObject.SetActive(false);
    }
}
