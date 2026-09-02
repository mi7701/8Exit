using UnityEngine;

public class FadeInSprite : MonoBehaviour
{
    public float fadeSpeed = 0.3f;
    public float targetAlpha = 0.3f;

    private SpriteRenderer sr;
    private bool fadingOut = false;

    void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();

        Color color = sr.color;
        color.a = 0f;
        sr.color = color;

        fadingOut = false;
    }

    void Update()
    {
        Color color = sr.color;

        if (!fadingOut)
        {
            color.a = Mathf.MoveTowards(
                color.a,
                targetAlpha,
                fadeSpeed * Time.deltaTime
            );
        }
        else
        {
            color.a = Mathf.MoveTowards(
                color.a,
                0f,
                fadeSpeed * Time.deltaTime
            );
        }

        sr.color = color;
    }

    public void FadeOut()
    {
        fadingOut = true;
    }
}