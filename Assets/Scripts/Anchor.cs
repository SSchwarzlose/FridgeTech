using UnityEngine;
using System.Collections;

public class Anchor : MonoBehaviour 
{
    Color newColor = new Color(0.0f, 1.0f, 0.0f, 0.5f);
    void OnMouseEnter()
    {
        this.GetComponent<Renderer>().material.color = newColor;
    }

    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.clear;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this.GetComponent<Renderer>().material.color = Color.green;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        this.GetComponent<Renderer>().material.color = Color.white;
    }
}
