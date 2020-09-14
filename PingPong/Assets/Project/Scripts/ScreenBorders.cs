using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBorders : MonoBehaviour
{
    public static float TopBorder { get; private set; }
    public static float BottomBorder { get; private set; }
    public static float LeftBorder { get; private set; }
    public static float RightBorder { get; private set; }

    [SerializeField] Transform _leftBorder;
    [SerializeField] Transform _rightBorder;

    private void Awake()
    {
        var camera = Camera.main;
        TopBorder = camera.ScreenToWorldPoint(new Vector2(0, camera.pixelHeight)).y;
        BottomBorder = camera.ScreenToWorldPoint(new Vector2(0, 0)).y;
        LeftBorder = camera.ScreenToWorldPoint(new Vector2(0, 0)).x;
        RightBorder = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, 0)).x;
        SetBorders();
    }

    private void SetBorders()
    {
        _leftBorder.position = new Vector2(LeftBorder, 0);
        _rightBorder.position = new Vector2(RightBorder, 0);
    }
}

