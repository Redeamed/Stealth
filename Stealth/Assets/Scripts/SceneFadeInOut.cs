using UnityEngine;
using System.Collections;

public class SceneFadeInOut : MonoBehaviour {

	public float fadeSpeed = 1.5f;
    public CanvasRenderer canvasRenderer;
    private bool sceneStarting = true;
    
    void Awake()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
    }
    void Update()
    {
        if (sceneStarting)
        {
            StartScene();

        }
        //else { EndScene(); }
    }

    void FadeToClear()
    {
        canvasRenderer.SetAlpha(Mathf.Lerp(canvasRenderer.GetAlpha(), 0, fadeSpeed * Time.deltaTime));
    }
    void FadeToBlack()
    {
        canvasRenderer.SetAlpha(Mathf.Lerp(canvasRenderer.GetAlpha(), 1, fadeSpeed * Time.deltaTime));
    }
    void StartScene()
    {
        FadeToClear();
        if(canvasRenderer.GetAlpha() <= 0.05f)
        {
            canvasRenderer.SetAlpha(0);
            //canvasRenderer.gameObject.SetActive(false);
            sceneStarting = false;
        }
    }

    public void EndScene()
    {
        //canvasRenderer.gameObject.SetActive(true);
        
        FadeToBlack();

        if (canvasRenderer.GetAlpha() >= .95f)
        {
            Application.LoadLevel(1);
        }
    }
}
