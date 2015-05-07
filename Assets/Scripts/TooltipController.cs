// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TooltipController.cs" company="">
//   
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// TODO 
/// </summary>
public class TooltipController : MonoBehaviour
{
    /// <summary>
    /// TODO 
    /// </summary>
    [SerializeField]
    private Text tooltipText;

    /// <summary>
    /// TODO 
    /// </summary>
    private PointerEventData eventData;

    /// <summary>
    /// TODO 
    /// </summary>
    private Button button;

    /// <summary>
    /// TODO 
    /// </summary>
    public bool isEnabled = false;

    // Use this for initialization
    /// <summary>
    /// TODO 
    /// </summary>
    private void Start()
    {
        this.tooltipText = this.GetComponentInChildren<Text>();
        tooltipText.enabled = false;
    }

    // Update is called once per frame
    /// <summary>
    /// TODO 
    /// </summary>
    private void Update()
    {
    }

    /// <summary>
    /// TODO 
    /// </summary>
    public void ShowTooltip()
    {
        this.tooltipText.enabled = true;
    }

    /// <summary>
    /// TODO 
    /// </summary>
    public void HideTooltip()
    {
        this.tooltipText.enabled = false;
    }
}