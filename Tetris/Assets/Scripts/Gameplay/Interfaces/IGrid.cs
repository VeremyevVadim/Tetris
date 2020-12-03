using System;

public interface IGrid
{
    bool IsTetrominoValidPosition(Tetromino tetromino);
    void TetrominoFall(Tetromino tetromino);
    
    int Width { get; }
    int Height { get; }
    
    event Action<int> LinesDestroyed;
    event Action EndGame;
}
