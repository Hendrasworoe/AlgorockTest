using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public UnityAction<GameState> OnGameStateChanged = delegate { };

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        OnGameStateChanged = delegate { };
    }

    private void HandleGamePlay()
    {
        Time.timeScale = 1f;
    }

    private void HandleGameOver()
    {
        Time.timeScale = 0f;
    }

    public void UpdateGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.GamePlay: HandleGamePlay(); break;
            case GameState.GameOver: HandleGameOver(); break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    public void PlayGame()
    {
        UpdateGameState(GameState.GamePlay);
    }
}
