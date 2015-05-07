//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="LessonEventController.cs" company="Sascha Schwarzlose">
//    copyright 2015 by Sascha Schwarzlose
//  </copyright>
//  <summary>
//    TODO
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using Assets.Scripts;

using UnityEngine;
using System.Collections;

public class LessonEventController : MonoBehaviour
{
    public delegate void SetTile(Tile tile, GameObject targetAnchor);

    public event SetTile TilePlaced;

    private static LessonEventController controller;
    public static LessonEventController Instance
    {
        get
        {
            if (controller == null)
            {
                controller = GameObject.FindObjectOfType<LessonEventController>() as LessonEventController;
                if (controller == null)
                {
                    GameObject go = new GameObject("LessonController");
                    controller = go.AddComponent<LessonEventController>();
                }
            }
            return controller;
        }
    }


    
    public void OnTilePlaced(Tile tile, GameObject targetAnchor)
    {
        SetTile handler = this.TilePlaced;
        if (handler != null)
        {
            handler(tile, targetAnchor);
        }
    }

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else
        {
            if(this != controller)
                Destroy(this.gameObject);
        }
    }
}
