// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Lesson3.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections;

using Assets.Scripts;

using UnityEngine;

/// <summary>
/// TODO 
/// </summary>
public class Lesson3 : MonoBehaviour
{
    /// <summary>
    /// TODO 
    /// </summary>
    [SerializeField]
    private int _tileCount;

    /// <summary>
    /// TODO 
    /// </summary>
    [SerializeField]
    private int _anchorCount;

    /// <summary>
    /// TODO 
    /// </summary>
    public LessonEventController Controller;

    /// <summary>
    /// TODO 
    /// </summary>
    public Animator Panel_LessonEnd;

    /// <summary>
    /// TODO 
    /// </summary>
    public ScreenManager ScreenManager;

    /// <summary>
    /// TODO 
    /// </summary>
    private void Start()
    {
        Controller = GameObject.FindGameObjectWithTag(Tags.LessonController).GetComponent<LessonEventController>();
        Controller.TilePlaced += this.CheckTilePosition;
        GameObject[] Anchors = GameObject.FindGameObjectsWithTag(Tags.Anchor);
        _anchorCount = Anchors.Length;

        Debug.Log("Anchors: " + _anchorCount);
        Debug.Log("Tiles: " + _tileCount    );
    }

    /// <summary>
    /// TODO 
    /// </summary>
    private void Update()
    {
        if (_tileCount >= _anchorCount)
        {
            this.Invoke("OnLessonEnd", 1);
        }
    }

    /// <summary>
    /// TODO 
    /// </summary>
    /// <param name="tile">
    /// TODO 
    /// </param>
    /// <param name="target">
    /// TODO 
    /// </param>
    private void CheckTilePosition(Tile tile, GameObject target)
    {
        if (target.name == "Anchor_" + tile.name)
        {
            tile.isInRightPlace = true;
            _tileCount++;
        }
        else
        {
            tile.isInRightPlace = false;
        }
    }

    /// <summary>
    /// TODO 
    /// </summary>
    private void OnLessonEnd()
    {
        ScreenManager.OpenPanel(Panel_LessonEnd);
    }

    /// <summary>
    /// TODO 
    /// </summary>
    public void OnClickButtonBack()
    {
        Application.LoadLevel("Main");
    }

    void ShowDebugInfo()
    {
        Debug.Log("TileCount: "+ _tileCount);
        Debug.Log("Anchorcount: " + _anchorCount);
    }
}