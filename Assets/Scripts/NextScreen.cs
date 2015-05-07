using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NextScreen : MonoBehaviour
{
    private GameManager gameManager;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null) Debug.Log("GameManager nicht gefunden");
    }

    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        gameManager.LoadScene("Main");
    }
}
