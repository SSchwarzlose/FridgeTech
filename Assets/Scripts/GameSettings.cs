//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GameSettings.cs" company="Sascha Schwarzlose">
//    copyright 2015 by Sascha Schwarzlose
//  </copyright>
//  <summary>
//    TODO
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using UnityEngine;

[Serializable]
public class GameSettings  :ScriptableObject
{
    public bool ShowInfoscreen = true;
    public int ScreenWidth;
    public int ScreenHeight;
    public bool Fullscreen = false;
    public string Username = "Azubi";

}