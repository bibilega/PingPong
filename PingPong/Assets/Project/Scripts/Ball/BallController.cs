using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool _isInitialized = false;

    private BallConfig _data;
    private GameController _gameController;
    private ScoreController _scoreController;

    private Transform _transform;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _currentDirection;

    public Color BallColor => _data.Color;

    public void Initialize(BallConfig data, GameController gameController, ScoreController scoreController)
    {
        _gameController = gameController;
        _scoreController = scoreController;
        _transform = transform;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentDirection = GetRandomDirection();
        Initialize(data);

    }

    public void Restart()
    {
        BallConfig data = _gameController.GetRandomBallData();
        data.Color = _data.Color;
        Initialize(data);
    }

    public void SetColor(Color color)
    {
        _data.Color = color;
        _spriteRenderer.color = _data.Color;
    }

    private void Initialize(BallConfig data)
    {
        _data = data;
        _transform.localScale = _data.Scale;
        _spriteRenderer.color = _data.Color;
        Spawn();
        _currentDirection = GetRandomDirection();
        _isInitialized = true;
    }

    private void FixedUpdate()
    {
        if (!_isInitialized)
            return;

        _rigidbody2D.velocity = _currentDirection * Time.deltaTime*_data.Speed;

        if(IsOutPosition())
        {
            _scoreController.ResetCurrentScore();
            Spawn();
            _currentDirection = GetRandomDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _currentDirection = Vector2.Reflect(_currentDirection, collision.contacts[0].normal);
        if (collision.transform.tag.Equals("Bat"))
            _scoreController.AddCurrentScore();
    }

    private void Spawn()
    {
        _rigidbody2D.position = new Vector2(0, 0);
    }

    private Vector2 GetRandomDirection()
    {
        var x = UnityEngine.Random.Range(-1f, 1f);
        var y = UnityEngine.Random.Range(-1f, 1f);
        return new Vector2(x, y).normalized;
    }

    private bool IsOutPosition()
    {
        return (_rigidbody2D.position.y > ScreenBorders.TopBorder || _rigidbody2D.position.y < ScreenBorders.BottomBorder);
    }

 
}
