using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }

    public UnityAction OnScoreChanged = delegate { };

    public int score { get; private set; }

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

        score = 0;
    }

    public void AddScore(int scoreAdder)
    {
        score += scoreAdder;

        OnScoreChanged?.Invoke();
    }

    public void ResetScore()
    {
        score = 0;

        OnScoreChanged?.Invoke();
    }
}
