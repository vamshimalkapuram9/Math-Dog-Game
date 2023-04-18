using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public GameObject objectToAnimate;
    public Animator objectToAnimateAnimator;

    public void Start()
    {
        // Get the animator component of the object to animate
        objectToAnimateAnimator = objectToAnimate.GetComponent<Animator>();
    }

    public void AnimateObject()
    {
        // Trigger the animation in the object to animate
        objectToAnimateAnimator.SetTrigger("YourTriggerName");
    }

    public void StopAnimation()
    {
        // Stop the animation in the object to animate
        objectToAnimateAnimator.speed = 0f;
    }
}

