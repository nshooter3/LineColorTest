using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    public enum GameState { Playing, Win, Die };
    [HideInInspector]
    public GameState gameState = GameState.Playing;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Win()
    {
        gameState = GameState.Win;
        CanvasManager.instance.ActivateWinScreen();
    }

    public void Die(float completion)
    {
        gameState = GameState.Die;
        CanvasManager.instance.ActivateLoseScreen(completion);
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    private IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
