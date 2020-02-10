using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class HoverOverBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    float timestamp;
    public float duration = 1;

    public GameObject descriptionOnHover;

    // Use this for initialization
    void Start()
    {
        HideDescription();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOver)
        {
            if (Time.time > timestamp + duration)
            {
                Debug.Log(Time.time);
                ShowDescription();
            }
        }
    }

    private void OnMouseEnter()
    {
        timestamp = Time.time;
    }

    private void OnMouseOver()
    {
        if (Time.time > timestamp + duration)
        {
            Debug.Log(Time.time);
            ShowDescription();
        }
    }

    private void OnMouseExit()
    {
        timestamp = Time.time;
        HideDescription();
    }

    void ShowDescription()
    {
        descriptionOnHover.SetActive(true);
    }

    void HideDescription()
    {
        descriptionOnHover.SetActive(false);
    }

    bool isOver;
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        timestamp = Time.time;
        isOver = true;
        Debug.Log("Pointer entered HoverOverUI element.");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        timestamp = Time.time;
        HideDescription();
        isOver = false;
    }

}
