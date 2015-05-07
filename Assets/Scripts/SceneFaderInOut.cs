using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class SceneFaderInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    public Image fadeImage;

    private bool sceneStarting = true;

    void Awake()
    {
        fadeImage.rectTransform.SetAsLastSibling();
        DontDestroyOnLoad(gameObject);
        //guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    void Start()
    {
        fadeImage.enabled = true;
    }

    void Update()
    {
        if(sceneStarting)
            this.StartScene();
    }

    void FadeToClear()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
        
        //guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void FadeToBlack()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeSpeed * Time.deltaTime);
        //guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {
        this.FadeToClear();
        if (fadeImage.color.a <= 0.05f)
        {
            fadeImage.color = Color.clear;
            fadeImage.enabled = false;
            sceneStarting = false;
        }
        //if (guiTexture.color.a <= 0.05f)
        //{
        //    guiTexture.color = Color.clear;
        //    guiTexture.enabled = false;
        //    sceneStarting = false;
        //}
    }

    public void EndScene(string levelname)
    {
        fadeImage.enabled = true;
        this.FadeToBlack();

        if (fadeImage.color.a >= 0.95f)
        {
            Application.LoadLevel(levelname);
        }
    }
}
