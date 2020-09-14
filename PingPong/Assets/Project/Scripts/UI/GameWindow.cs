using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour
{
    private ScoreController _scoreController;
    private SettingsWindow _settingsWindow;
    private Action _restart;

    [SerializeField] private Button restartBtn;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Button settingsBtn;

    public void Initialize( Action restart, ScoreController scoreController, SettingsWindow settingsWindow)
    {
        _restart = restart;
        _scoreController = scoreController;
        _settingsWindow = settingsWindow;
        restartBtn.onClick.AddListener(Restart);
        bestScoreText.text = string.Format("Best Score: {0}", _scoreController.BestScore);
        currentScoreText.text = string.Format("Score: {0}", _scoreController.CurrentScore);
        _scoreController.BestScoreChange.AddListener(UpdateBestScore);
        _scoreController.CurrentScoreChange.AddListener(UpdateCurrentScore);
        settingsBtn.onClick.AddListener(OpenSettings);
    }

    private void Restart()
    {
        _scoreController.ResetCurrentScore();
        _restart.Invoke();
    }

    private void UpdateBestScore()
    {
        bestScoreText.text = string.Format("Best Score: {0}", _scoreController.BestScore);
    }

    private void UpdateCurrentScore()
    {
        currentScoreText.text = string.Format("Score: {0}", _scoreController.CurrentScore);
    }

    private void OpenSettings()
    {
        _settingsWindow.Open();
    }

    private void OnDestroy()
    {
        restartBtn.onClick.RemoveAllListeners();
        _scoreController.BestScoreChange.RemoveListener(UpdateBestScore);
        _scoreController.CurrentScoreChange.RemoveListener(UpdateCurrentScore);
        settingsBtn.onClick.RemoveAllListeners();
    }
}
