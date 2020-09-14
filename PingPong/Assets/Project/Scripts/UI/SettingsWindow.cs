using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    private GameObject _gameObject;
    private Action<Color> _setColorAction;

    [SerializeField] List<ColorPanel> colorPanels;
    [SerializeField] private Button closeBtn;

    public void Initialize(Action<Color> setColorAction)
    {
        _gameObject = gameObject;
        _setColorAction = setColorAction;

        foreach (var panel in colorPanels)
            panel.Initialize(this);

        closeBtn.onClick.AddListener(Close);
    }

    public void Open()
    {
        _gameObject.SetActive(true);
    }

    public void Close()
    {
        _gameObject.SetActive(false);
    }

    public void SetColor(Color color)
    {
        _setColorAction.Invoke(color);
        Close();
    }
}
