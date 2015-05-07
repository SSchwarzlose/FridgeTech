using UnityEngine;
using System.Collections;

public class Anchor : MonoBehaviour 
{
    Color newColor = new Color(0.0f, 1.0f, 0.0f, 0.5f);
    void OnMouseEnter()
    {
        this.renderer.material.color = newColor;
    }

    void OnMouseExit()
    {
        this.renderer.material.color = Color.clear;
    }
}
