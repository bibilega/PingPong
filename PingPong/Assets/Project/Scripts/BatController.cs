using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BatController : MonoBehaviour, IDragHandler
{
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidbody2D;
    private float _leftBorder;
    private float _rightBorder;

    [SerializeField] private ScreenSide _batScreenSide;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _leftBorder = ScreenBorders.LeftBorder + _boxCollider2D.size.x/2;
        _rightBorder = ScreenBorders.RightBorder - _boxCollider2D.size.x / 2;
        _rigidbody2D.position = new Vector2(0, GetStartYByScreenSide());
    }

    private float GetStartYByScreenSide()
    {
        switch(_batScreenSide)
        {
            case ScreenSide.Top:
                return ScreenBorders.TopBorder - _boxCollider2D.size.y / 2;
            default:
                return ScreenBorders.BottomBorder + _boxCollider2D.size.y / 2;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        var newPosition =  _rigidbody2D.position + new Vector2(eventData.delta.x*Time.deltaTime, 0);
        if (newPosition.x > _leftBorder && newPosition.x < _rightBorder)
            _rigidbody2D.position = newPosition;
    }

    public enum ScreenSide
    {
        Top,
        Bottom
    }
}
