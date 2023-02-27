using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private CanvasGroup _itsCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        _itsCanvasGroup = GetComponent<CanvasGroup>();
        GameManager.Instance.OnGameStateChanged += ShowThisPanel;
    }

    private void ShowThisPanel(GameState gameState)
    {
        bool is_gameover = (gameState == GameState.GameOver);

        _itsCanvasGroup.alpha = is_gameover ? 1 : 0;
        _itsCanvasGroup.interactable = is_gameover;
        _itsCanvasGroup.blocksRaycasts = is_gameover;
    }
}
