using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;
    public CanvasRenderer canvasRenderer;
    private float alpha = 1;
    private bool sceneStarting = true;

    void Awake()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
        canvasRenderer.SetAlpha(alpha) ;
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();

        }
    }

    void FadeToClear()
    {
        canvasRenderer.SetAlpha(Mathf.Lerp(alpha, 0, fadeSpeed * Time.deltaTime));
    }
    void FadeToBlack()
    {
        canvasRenderer.SetAlpha(Mathf.Lerp(alpha, 255.0f, fadeSpeed * Time.deltaTime));
    }
    void StartScene()
    {
        FadeToClear();
        if(canvasRenderer.GetAlpha() <= 0.25f)
        {
            alpha = 0;
            canvasRenderer.SetAlpha(alpha);
            //canvasRenderer.gameObject.SetActive(false);
            sceneStarting = false;
        }
    }

    public void EndScene()
    {
        canvasRenderer.gameObject.SetActive(true);
        FadeToBlack();

        if (canvasRenderer.GetAlpha() >= 0.95f)
        {
            Application.LoadLevel(1);
        }
    }
}
