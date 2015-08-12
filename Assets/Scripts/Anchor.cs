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

    void OnCollisionEnter2D(Collision2D col)
    {
        this.renderer.material.color = newColor;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        this.renderer.material.color = Color.clear;
    }
}
