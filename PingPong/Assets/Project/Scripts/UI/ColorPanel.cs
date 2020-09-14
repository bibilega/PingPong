using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanel : MonoBehaviour
{
    private SettingsWindow _settingsWindow;
    private Button _button;
    [SerializeField] private Color _color;

    public void Initialize(SettingsWindow settingsWindow)
    {
        _settingsWindow = settingsWindow;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ChooseColor);
    }

    private void ChooseColor()
    {
        _settingsWindow.SetColor(_color);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(ChooseColor);
    }
}
