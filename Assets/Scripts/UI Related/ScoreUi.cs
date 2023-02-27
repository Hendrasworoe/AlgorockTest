using UnityEngine;
using TMPro;

public class ScoreUi : MonoBehaviour
{
    private TMP_Text _itsText;

    private void Awake()
    {
        _itsText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;

        UpdateScoreText();
    }

    private void OnDestroy()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        _itsText.text = ScoreManager.Instance.score.ToString();
    }
}
