using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.EventSystems;

public class Lesson2 : MonoBehaviour
{
    [SerializeField]
    private int _tileCounter;
    [SerializeField]
    private int _anchorCount;
    public LessonEventController controller;
    public Animator Panel_LessonEnd;
    public ScreenManager ScreenManager;


    void Start()
    {
        controller = GameObject.FindGameObjectWithTag(Tags.LessonController).GetComponent<LessonEventController>();
        controller.TilePlaced += this.CheckTilePosition;
        GameObject[] Anchors = GameObject.FindGameObjectsWithTag(Tags.Anchor);
        _anchorCount = Anchors.Length;
    }

    void Update()
    {
        if (_tileCounter >= _anchorCount)
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
