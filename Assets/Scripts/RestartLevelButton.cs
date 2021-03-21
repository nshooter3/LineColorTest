using UnityEngine;
using UnityEngine.UI;

public class RestartLevelButton : MonoBehaviour
{
    public Button button;
    public Animator animator;

    public void OnClick()
    {
        button.interactable = false;
        animator.SetTrigger("Click");
        GameStateManager.instance.RestartLevel();
    }
}
