using UnityEngine;
using System.Collections;

public class BlackScreenFadeControl : MonoBehaviour
{
    public bool fadeBlack1to0;
    public float fadeduration;
    
    Animator animator;
    //'parameter = Fade0-1
    //'paramter = Fade1-0

    // Use this for initialization
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (fadeBlack1to0)
        { animator.SetTrigger("Fade1-0"); }
        animator.speed = fadeduration / animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        Debug.Log("Playing speed is " + animator.speed);
        Debug.Log("Duration of animation should be is " + fadeduration);
        Debug.Log("Current Animation Clip duration is " + animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }




    /*  public IEnumerator FadeIn(float startingAlpha, float endingAlpha, float duration)
    {

        //yield return new WaitForSeconds();

    }
    */

}
