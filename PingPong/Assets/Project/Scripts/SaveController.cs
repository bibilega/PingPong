using System.Collections;
using System;
using System.IO;
using UnityEngine;

public class SaveController 
{
    private const string _fileName = "data.json";

    public static void Save(ScoreController scoreController, BallController ballController)
    {
        var gameSave = new GameSave(scoreController.BestScore, ballController.BallColor);
        string json = JsonUtility.ToJson(gameSave);

        var path = string.Concat(Application.persistentDataPath, _fileName);
        Debug.Log(path);
        try
        {
            File.WriteAllText(path, json);
        }
        catch(Exception e)
        {
            Debug.Log("При сохранении возникла ошибка: " + e);
        }
    }

    public static GameSave Load()
    {
        var path = string.Concat(Application.persistentDataPath, _fileName);

        if (!File.Exists(path))
        {
            Debug.Log("Файла сохранения не существует!");
            return default;
        }

        string json = File.ReadAllText(path);
        var gameSave = JsonUtility.FromJson<GameSave>(json);
        return gameSave;
    }
}

[Serializable]
public struct GameSave
{
    public int BestScore;

    public float _colorA;
    public float _colorR;
    public float _colorG;
    public float _colorB;

    public Color Color => new Color(_colorR, _colorG, _colorB, _colorA);

    public GameSave(int bestScore, Color color)
    {
        BestScore = bestScore;
        Debug.Log(color);
        _colorA = color.a;
        _colorR = color.r;
        _colorG = color.g;
        _colorB = color.b;
    }
}
