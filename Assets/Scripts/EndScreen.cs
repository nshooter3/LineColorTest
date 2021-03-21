using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public CanvasGroup group;

    private bool fadeIn;
    private float fadeInSpeed = 1f;

    public void StartEndScreen()
    {
        group.interactable = true;
        group.blocksRaycasts = true;
        fadeIn = true;
    }

    private void Update()
    {
        if (fadeIn && group.alpha <= 1f)
        {
            group.alpha += fadeInSpeed * Time.deltaTime;
        }
    }
}
