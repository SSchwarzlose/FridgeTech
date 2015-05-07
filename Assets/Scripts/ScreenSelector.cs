//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ScreenSelector.cs" company="Sascha Schwarzlose">
//    copyright 2015 by Sascha Schwarzlose
//  </copyright>
//  <summary>
//    TODO
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ScreenSelector : MonoBehaviour 
{
    public void StartLesson(int level)
    {
        Application.LoadLevel(level);
    }

    public void StartLessonName(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
