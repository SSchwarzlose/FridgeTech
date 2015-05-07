using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public Animator InitiallyOpen;

    private Animator open;

    private int openParameterId;

    private GameObject previouslySelected;

    private const string OpenTransitionName = "Open";

    private const string ClosedStateName = "Closed";

    public void OnEnable()
    {
        openParameterId = Animator.StringToHash(OpenTransitionName);

        if (InitiallyOpen == null) return;
        OpenPanel(InitiallyOpen);
    }

    private GameObject FindFirstEnabledSelectable(GameObject o)
    {
        GameObject go = null;
        var selectables = gameObject.GetComponentsInChildren<Selectable>(true);
        foreach (var selectable in selectables)
        {
            if (selectable.IsActive() && selectable.IsInteractable())
            {
                go = selectable.gameObject;
                break;
            }
        }
        return go;
    }

    private void SetSelected(GameObject go)
    {
        EventSystem.current.SetSelectedGameObject(go);

        var standaloneInputModule = EventSystem.current.currentInputModule as StandaloneInputModule;
        if (standaloneInputModule != null && standaloneInputModule.inputMode == StandaloneInputModule.InputMode.Buttons) return;

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OpenPanel(Animator animator)
    {
        if (this.open == animator) return;
        animator.gameObject.SetActive(true);

        var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

        animator.transform.SetAsLastSibling();

        CloseCurrent();

        previouslySelected = newPreviouslySelected;

        open = animator;
        open.SetBool(openParameterId, true);

        GameObject go = FindFirstEnabledSelectable(animator.gameObject);
        SetSelected(go);
    }

    public void CloseCurrent()
    {
        if (open == null) return;
        open.SetBool(openParameterId, false);
        this.SetSelected(previouslySelected);
        StartCoroutine(DisablePanelDelayed(open));

        open = null;
    }

    private IEnumerator DisablePanelDelayed(Animator animator)
    {
        bool closedStateReached = false;
        bool wantToClose = true;

        while (!closedStateReached && wantToClose)
        {
            if (!animator.IsInTransition(0)) closedStateReached = animator.GetCurrentAnimatorStateInfo(0).IsName(ClosedStateName);

            wantToClose = !animator.GetBool(openParameterId);

            yield return new WaitForEndOfFrame();
        }

        if(wantToClose)animator.gameObject.SetActive(false);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
