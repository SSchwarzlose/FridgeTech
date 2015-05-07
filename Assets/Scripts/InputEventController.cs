using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InputEventController : MonoBehaviour 
{
    public delegate void StartButtonClicked(int levelToLoad);

    public event StartButtonClicked OnStartButtonClicked;

    protected virtual void OnClickStartbuttonClicked(int leveltoload)
    {
        StartButtonClicked handler = this.OnStartButtonClicked;
        if (handler != null)
        {
            handler(leveltoload);
        }
    }

    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    
}
