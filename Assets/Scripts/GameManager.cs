
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    //private bool isSceneEnding = false;
    private string nextScene;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>() as GameManager;
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    DontDestroyOnLoad(instance.gameObject);
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(this != instance)
                Destroy(this.gameObject);
        }
    }

	// Update is called once per frame
	void Update () 
    {
        if (Application.loadedLevel == 0)
        {
            if (Time.timeSinceLevelLoad >= 4)
            {
                Application.LoadLevel("InfoScreen");
            }
        }
	}
    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
