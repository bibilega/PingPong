using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private GameWindow gameWindow;
    [SerializeField] private SettingsWindow settingsWindow;

    [SerializeField] List<BallConfig> _allBallData;

    private void Start()
    {
        var gameSave = SaveController.Load();

        BallConfig ballData = GetRandomBallData();
        Color ballColor = gameSave.Color;
        if (ballColor.a == 0)
            ballColor = Color.white;
        ballData.Color = ballColor;
        ballController.Initialize(ballData, this, scoreController);

        ScoreData scoreData = new ScoreData(gameSave.BestScore);
        scoreController.Initialize(scoreData);

        gameWindow.Initialize(ballController.Restart, scoreController, settingsWindow);
        settingsWindow.Initialize(ballController.SetColor);
    }

    private void OnApplicationQuit()
    {
        SaveController.Save(scoreController, ballController);
    }

    public BallConfig GetRandomBallData()
    {
        var i = Random.Range(0, _allBallData.Count);
        return _allBallData[i];
    }
}
