using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FaderController : MonoBehaviour
{
    [SerializeField]
    float fadeSpeed = 1F;

    Image fadeImage;

    public enum FadeDirection
    {
        IN,
        OUT
    }

    void Awake()
    {
        fadeImage = GetComponent<Image>();
    }

    void OnEnable()
    {
        StartCoroutine(Fade(FadeDirection.OUT));
    }

    IEnumerator Fade(FadeDirection direction)
    {
        float alpha = direction == FadeDirection.OUT ? 1 : 0;
        float endValue = direction == FadeDirection.OUT ? 0 : 1;

        if (direction == FadeDirection.OUT)
        {
            while (alpha > endValue)
            {
                SetColor(ref alpha, direction);
                yield return null;
            }
            fadeImage.enabled = false;
        }
        else
        {
            fadeImage.enabled = true;
            while (alpha <= endValue)
            {
                SetColor(ref alpha, direction);
                yield return null;
            }
        }
    }

    void SetColor(ref float alpha, FadeDirection direction)
    {
        int factor = direction == FadeDirection.OUT ? -1 : 1;
        Color color = fadeImage.color;
        fadeImage.color = new Color(color.r, color.g, color.b, alpha);
        alpha += Time.deltaTime * (1F / fadeSpeed) * factor;
    }

    public IEnumerator FadeAndLoadScene(FadeDirection direction, int sceneIndex)
    {
        yield return Fade(direction);
        SceneManager.LoadScene(sceneIndex);
    }
}
