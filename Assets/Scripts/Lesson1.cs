using Assets.Scripts;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    [SerializeField]
    private int _tileCounter;
    public LessonEventController controller;
    public Animator Panel_LessonEnd;
    public ScreenManager ScreenManager;
    
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag(Tags.LessonController).GetComponent<LessonEventController>();
        controller.TilePlaced += this.CheckTilePosition;
    }
    void Update()
    {
        if (_tileCounter >= 4)
            this.Invoke("OnLessonEnd", 1); 
    }

    void CheckTilePosition(Tile tile, GameObject target)
    {
        if (target.name == "Anchor_" + tile.name)
        {
            tile.isInRightPlace = true;
            _tileCounter++;
        }
        else
        {
            tile.isInRightPlace = false;
        }
    }

    private void OnLessonEnd()
    {
        ScreenManager.OpenPanel(Panel_LessonEnd);
    }

    public void OnClickButtonBack()
    {
        Application.LoadLevel("Main");
    }
}