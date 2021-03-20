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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Die()
    {
        gameState = GameState.Die;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
