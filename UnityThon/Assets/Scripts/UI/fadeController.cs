using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeController : MonoBehaviour
{
    float fadeSpeed = 0.001f;
    float fadeAlpha;
    public bool isFadeOut = false;
    Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        fadeAlpha = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeOut){
            FadeOut();
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        fadeAlpha += fadeSpeed;
        SetAlpha(fadeAlpha);
        if(fadeAlpha >= 1)
        {
            isFadeOut = false;
        }
    }
    void SetAlpha(float a)
    {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, a);
    }

    public void StartFadeOut()
    {
        isFadeOut = true;
        FadeOut();
    }
}
