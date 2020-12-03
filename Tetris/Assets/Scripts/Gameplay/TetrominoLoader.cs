using System;
using UnityEngine;

public class TetrominoLoader: ITetrominoLoader
{
    private Tetromino[] _tetrominos;
    
    public Tetromino[] LoadTetrominos()
    {
        LoadTetrominosFromResources();
        return _tetrominos;
    }
    
    private void LoadTetrominosFromResources()
    {
        _tetrominos = Resources.LoadAll<Tetromino>("Prefabs/Tetrominos");
        if (_tetrominos.Length == 0)
        {
            throw new Exception("There is no tetromino prefabs in Resources/Prefabs/Tetrominos");
        }
    }
}
