using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelasButton : MonoBehaviour
{
    public AudioClip takesFocus;
    public AudioClip losesFocus;
    public AudioClip confirmOnClick;
    public AudioClip cancelOnClick;

    AudioManagerSoundEffects audioManagerSoundEffects;
    CursorManager cursorManager;

    [SerializeField]
    bool isConfirm;

    private void Awake()
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickCheck();

    }

    private void OnMouseEnter()
    {
        audioManagerSoundEffects.PlaySoundEffect(takesFocus);
        cursorManager.SpecialCursor();
    }

    private void OnMouseExit()
    {
        audioManagerSoundEffects.PlaySoundEffect(losesFocus);
        cursorManager.SimpleCursor();
    }

    private void OnMouseUpAsButton()
    {
        if (isConfirm)
        {
            audioManagerSoundEffects.PlaySoundEffect(confirmOnClick);
        }
        else
        {
            audioManagerSoundEffects.PlaySoundEffect(cancelOnClick);
        }
    }


    //Ignore....
    //I forgot there is a onmouse...
    void ClickCheck()
    {
        if
               (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;

            if
                (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
            {
                if
                    (raycastHit.transform.gameObject.name == this.gameObject.name)
                {
                    Debug.Log("You got a click.");
                }
            }
        }
    }

}
