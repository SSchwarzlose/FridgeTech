
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    //private bool isSceneEnding = false;
    private string _nextScene;
    public GameSettings GameSettings;
    public Toggle InfoscreenToggle;

    private int ScreenWidth;
    private int ScreenHeight;
    private bool _fullscreen;
    public Toggle FullscreenToggle;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>() as GameManager;
                if (_instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    DontDestroyOnLoad(_instance.gameObject);
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (GameSettings != null)
        {
            LoadGameSettings();
        }

        if (Application.loadedLevel==2)
        {
            FullscreenToggle = FindObjectOfType<Toggle>();
            
        }
    }

    void Start()
    {
        
    }

	// Update is called once per frame
	void Update () 
    {
        if (Application.loadedLevelName == "SplashScreen" )
        {
            if (Time.timeSinceLevelLoad >= 4 )
            {
                Application.LoadLevel(this.GameSettings.ShowInfoscreen ? "InfoScreen" : "Main");
            }
        }

	    if (FullscreenToggle != null)
	    {

	    }
	}
    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void SaveGameSettings()
    {
        GameSettings.Fullscreen = this._fullscreen;
        GameSettings.ScreenWidth = this.ScreenWidth;
        GameSettings.ScreenHeight = this.ScreenHeight;
    }

    private void LoadGameSettings()
    {
        this.ScreenWidth = GameSettings.ScreenWidth;
        this.ScreenHeight = this.GameSettings.ScreenHeight;
        this._fullscreen = GameSettings.Fullscreen;
        if(FullscreenToggle!=null)
            FullscreenToggle.isOn = _fullscreen;
    }

    public void SaveInfoscreenSettings()
    {
        this.GameSettings.ShowInfoscreen = this.InfoscreenToggle;
    }

    public void SaveUsername(string username)
    {
        this.GameSettings.Username = username;
    }

    public void SetResolution(int index)
    {
        switch (index)
        {
            case 1:
            {
                print("Auflösung: 1920x1080");
                this.GameSettings.ScreenWidth = 1920;
                this.GameSettings.ScreenHeight = 1080;
                Screen.SetResolution(1920, 1080, true);
                print(Screen.currentResolution);
            }break;
                
            case 2:
            {
                this.GameSettings.ScreenWidth = 1680;
                this.GameSettings.ScreenHeight = 1050;
                Screen.SetResolution(1680, 1050, this.GameSettings.Fullscreen);
            }break;
            case 3:
                Screen.SetResolution(1280, 720, GameSettings.Fullscreen);
                break;
        }
    }

    public void SetFullscreen(bool fullscreen)
    {
        this._fullscreen = FullscreenToggle.isOn;
        Screen.fullScreen = this._fullscreen;
        SaveGameSettings();
        Debug.Log("Fullscreen: " + this._fullscreen);
    }
}
