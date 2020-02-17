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

    public bool popsUpAnotherGameObject;
    public bool hidesSelf;
    public bool hidesParentGameObject;
    public GameObject popUpGameObject;

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
        AudioClip[] soundEffects = UnityEngine.Resources.LoadAll<AudioClip>("Audio\\Sounds\\UI SoundEffects\\ButtonSounds");
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

        if (popsUpAnotherGameObject)
        {
            ShowPopUp();
        }
        if (hidesParentGameObject)
        {
            HideParentGameObject();
        }
        if (hidesSelf)
        { 
            HideSelf(); 
        }

    }

    void ShowPopUp()
    {
        popUpGameObject.SetActive(true);
    }
    void HideParentGameObject()
    {
        GameObject parentScreen;
        RectTransform[] parents =  GetComponentsInParent<RectTransform>();

        foreach (RectTransform thisParent in parents)
        {
            if (thisParent.gameObject.tag == "FullScreenOverLay")
            {
                parentScreen = thisParent.gameObject;
                parentScreen.SetActive(false);
            }
            else
            {
                Debug.Log("FullScreenOverLay Screen not found.");
            }

        }

    }

    void HideSelf()
    {
        this.gameObject.active = false;
    }
}
