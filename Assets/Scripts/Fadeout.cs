using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UIElements;

public class Fadeout : MonoBehaviour
{

    SpriteRenderer sp;
    Color tmpcolor;

    [SerializeField] float fadeSpeed;
    [SerializeField] bool fadeOut;
    [SerializeField] bool fadeIn;

    [Range(0.75f, 1f)]
    [SerializeField] float maxFadeIn;
    [Range(0f, 0.60f)]
    [SerializeField] float maxFadeOut;

    // Start is called before the first frame update
    void Start()
    {
        sp.color = tmpcolor;
        fadeSpeed = Mathf.Clamp(fadeSpeed, 10f, 80f);

        tmpcolor = sp.color;
        sp.color = tmpcolor;
    }
    IEnumerator FadeEffect()
    {
        if(tmpcolor.a >= maxFadeIn)
        {
            fadeOut = true;
            fadeIn = false;
        }
        else if(tmpcolor.a < maxFadeOut)
        {
            fadeOut = false;
            fadeIn = true;
        }

        while(fadeOut)
        {
            tmpcolor.a -= Time.deltaTime;
            sp.color = tmpcolor;
            yield return null;
        }
        while(fadeIn)
        {
            tmpcolor.a += Time.deltaTime/ fadeSpeed;
            sp.color = tmpcolor;
            yield return null;
        }
    }
}
