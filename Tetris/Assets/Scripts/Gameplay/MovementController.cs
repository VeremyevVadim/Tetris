using System;
using UnityEngine;
using Zenject;

public class MovementController : IInitializable, ITickable, IDisposable
{
    public event Action<Tetromino> TetrominoFall;
    
    private readonly IGrid _grid;
    private readonly ISoundService _soundService;
    
    private Tetromino _tetromino;
    
    private float _defaultFallTimeSeconds;
    private float _fastFallTimeSeconds;
    private float _previousTime;

    private bool _disposed;
    
    public MovementController(
        IGrid grid,
        ISoundService soundService)
    {
        _grid = grid;
        _soundService = soundService;
    }
    
    public void Initialize()
    {
        TetrominoFall += _grid.TetrominoFall;
    }
    
    public void Tick()
    {
        if(_disposed) return;
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _tetromino.MoveRight();
            if (!_grid.IsTetrominoValidPosition(_tetromino))
            {
                _tetromino.MoveLeft();
            }
            else
            {
                _soundService.PlayMoveSound();
            }
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _tetromino.MoveLeft();
            if (!_grid.IsTetrominoValidPosition(_tetromino))
            {
                _tetromino.MoveRight();
            }
            else
            {
                _soundService.PlayMoveSound();
            }
        } 
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _tetromino.Rotate(90);
            if (!_grid.IsTetrominoValidPosition(_tetromino))
            {
                _tetromino.Rotate(-90);
            }
            else
            {
                _soundService.PlayRotateSound();
            }
        }
        
        MoveTetrominoDown();
    }

    private void MoveTetrominoDown()
    {
        var currentTime = Time.time;
        if (currentTime - _previousTime > GetFallTime())
        {
            _tetromino.MoveDown();
            if (!_grid.IsTetrominoValidPosition(_tetromino))
            {
                _soundService.PlayDropSound();
                
                _tetromino.MoveUp();
                _tetromino.enabled = false;
                TetrominoFall?.Invoke(_tetromino);
            }
            else
            {
                _soundService.PlayMoveSound();
                _previousTime = currentTime;
            }
        }
    }
    
    private float GetFallTime()
    {
        return (Input.GetKey(KeyCode.DownArrow)) ? _fastFallTimeSeconds : _defaultFallTimeSeconds;
    }

    public void Setup(Tetromino tetromino, float defaultFallTimeSeconds, float fastFallTimeSeconds)
    {
        _tetromino = tetromino;  
        _defaultFallTimeSeconds = defaultFallTimeSeconds;
        _fastFallTimeSeconds = fastFallTimeSeconds;
    }

    public void Dispose()
    {        
        if (_disposed) return;
        
        TetrominoFall -= _grid.TetrominoFall;
        _disposed = true;
    }
}
