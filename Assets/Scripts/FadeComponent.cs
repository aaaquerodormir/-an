using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeComponent : MonoBehaviour
{

    private Image fadeImage;
    private Color color;
    private Color transparentColor;
    // Start is called before the first frame update

    [Range(0.5f, 5)]
    [SerializeField] private float fadeOutDuration = 1f;

    [Range(0.5f, 5)]
    [SerializeField] private float fadeInDuration = 1f;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
        color = new Color(r: 0, g: 0, b: 0, a: 1);
        transparentColor = new Color(r: 0, g: 0, b: 0, a: 0);
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.8f);
        yield return StartCoroutine(routine: FadeIn());
        yield return null;
        yield return StartCoroutine(routine: FadeOut());
    }

    private IEnumerator DoFade(Color a, Color b, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.material.color = Color.Lerp(a, b, t: (elapsedTime / duration));
            yield return null;
        }
    }
    private IEnumerator FadeOut() // 1.0 > 0.0
    {
        yield return StartCoroutine(routine: DoFade(a: color, b: transparentColor, fadeOutDuration));
    }
    private IEnumerator FadeIn() // 0.0 > 10
    {
        yield return StartCoroutine(routine: DoFade(a: transparentColor, b: color, fadeInDuration));
    }
}
