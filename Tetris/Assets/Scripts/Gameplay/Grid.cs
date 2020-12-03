using System;
using System.Collections.Generic;
using Configs.Gameplay;
using UnityEngine;
using Zenject;

public class Grid : IInitializable, IGrid
{
    public event Action<int> LinesDestroyed;
    public event Action EndGame;

    public int Width { get;}
    public int Height { get; }

    private Transform[,] _grid;

    public Grid(IGridConfig gridConfig)
    {
        var gridConfig1 = gridConfig;
        
        Width = gridConfig1.Width;
        Height = gridConfig1.Height;
    }
    
    public void Initialize()
    {
        _grid = new Transform[Width, Height];
    }

    public bool IsTetrominoValidPosition(Tetromino tetromino)
    {
        foreach (Transform minoTransform in tetromino.transform)
        {
            if (!minoTransform.CompareTag("Mino"))
            {
                continue;
            }
            
            var position = minoTransform.position;
            var roundedX = Mathf.FloorToInt(position.x);
            var roundedY = Mathf.FloorToInt(position.y);

            if (!IsInsideGrid(roundedX, roundedY))
            {
                return false;
            }
            
            if(_grid[roundedX, roundedY] != null)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsInsideGrid(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0  && y < Height;
    }

    public void TetrominoFall(Tetromino tetromino)
    {
        if (!IsAboveTopLine(tetromino))
        {
            EndGame?.Invoke();
        }
        
        AddTetrominoToGrid(tetromino);
        
        var completedLineIndexes = FindCompletedLines();

        var deletedLineCount = 0;
        foreach (var lineIndex in completedLineIndexes)
        {
            DeleteCompletedLine(lineIndex);
            MoveUpperLinesDown(lineIndex);
            deletedLineCount++;
        }

        if (deletedLineCount > 0)
        {
            LinesDestroyed?.Invoke(deletedLineCount);
        }
    }

    private bool IsAboveTopLine(Tetromino tetromino)
    {
        foreach (Transform minoTransform in tetromino.transform)
        {
            if (!minoTransform.CompareTag("Mino")) continue;
            
            var roundedY = Mathf.FloorToInt(minoTransform.position.y);

            if (roundedY >= Height - 1)
            {
                return false;
            }
        }

        return true;
    }

    private void AddTetrominoToGrid(Tetromino tetromino)
    {
        foreach (Transform minoTransform in tetromino.transform)
        {
            if (!minoTransform.gameObject.CompareTag("Mino")) continue;
            
            var position = minoTransform.position;
            var roundedX = Mathf.FloorToInt(position.x);
            var roundedY   = Mathf.FloorToInt(position.y);
            _grid[roundedX, roundedY] = minoTransform;
        }
    }
    
    private IEnumerable<int> FindCompletedLines()
    {
        var completedLinesIndexes = new List<int>();
        for (var i = Height - 1; i >= 0; i--)
        {
            if (IsLineCompleted(i))
            {
                completedLinesIndexes.Add(i);
            }
        }

        return completedLinesIndexes;
    }
    
    private bool IsLineCompleted(int lineIndex)
    {
        for (var j = 0; j < Width; j++)
        {
            if (_grid[j, lineIndex] == null)
            {
                return false;
            }
        }
        
        return true;
    }
    
    private void DeleteCompletedLine(int lineIndex)
    {
        for (var j = 0; j < Width; j++)
        {
            UnityEngine.Object.Destroy(_grid[j, lineIndex].gameObject);
            _grid[j, lineIndex] = null;
        }
    }

    private void MoveUpperLinesDown(int lineIndex)
    {
        for (var line = lineIndex; line < Height; line++)
        {
            for (var column = 0; column < Width; column++)
            {
                if (_grid[column, line] == null) continue;
                
                _grid[column, line - 1] = _grid[column, line];
                _grid[column, line] = null;
                _grid[column, line - 1].transform.position += Vector3.down;
            }
        }
    }
}