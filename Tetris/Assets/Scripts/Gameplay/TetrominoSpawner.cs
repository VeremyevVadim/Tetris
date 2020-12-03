using System;
using Configs.Gameplay;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class TetrominoSpawner : MonoBehaviour, IUpgradable, IDisposable
{
    public event Action<Tetromino> OnPreviewTetrominoUpdated;
    
    private MovementController _movementController;
    private TetrominoConfig _tetrominoConfig;
    private DifficultyConfig _difficultyConfig;
    private ITetrominoLoader _tetrominoLoader;
    private IGrid _grid;
    
    private Tetromino[] _tetrominos;
    private Vector3 _spawnPoint;

    private float _defaultFallTimeSeconds;
    private float _fastFallTimeSeconds;

    private int _previewTetrominoIndex;
    
    [Inject]
    public void Construct(
        MovementController movementController,
        TetrominoConfig tetrominoConfig,
        DifficultyConfig difficultyConfig,
        ITetrominoLoader tetrominoLoader,
        IGrid grid)
    {
        _movementController = movementController;
        _tetrominoConfig = tetrominoConfig;
        _difficultyConfig = difficultyConfig;
        _tetrominoLoader = tetrominoLoader;
        _grid = grid;
    }
    
    private void Start()
    {
        _defaultFallTimeSeconds = _tetrominoConfig.DefaultFallTimeSeconds;
        _fastFallTimeSeconds = _tetrominoConfig.FastFallTimeSeconds;
        
        _movementController.TetrominoFall += SpawnRandomTetromino;

        SetupSpawnPoint();

        _tetrominos = _tetrominoLoader.LoadTetrominos();
        
        SpawnRandomTetromino(null);
    }

    private void SetupSpawnPoint()
    {
        var x = _grid.Width / 2f + 0.5f;
        var y = _grid.Height - 1.5f;
        _spawnPoint = new Vector3(x, y, -1);
    }

    private void OnDestroy()
    {
        _movementController.TetrominoFall -= SpawnRandomTetromino;
    }

    private void SpawnRandomTetromino(Tetromino tetromino)
    {
        var tetrominoInstance = Instantiate(GetPreviewTetromino(), _spawnPoint, Quaternion.identity);

        _movementController.Setup(tetrominoInstance, _defaultFallTimeSeconds, _fastFallTimeSeconds);

        _previewTetrominoIndex = Random.Range(0, _tetrominos.Length);
        OnPreviewTetrominoUpdated?.Invoke(GetPreviewTetromino());
    }

    private Tetromino GetPreviewTetromino()
    {
        return _tetrominos[_previewTetrominoIndex];
    }
    
    public void LevelUp()
    {
        _defaultFallTimeSeconds *= _difficultyConfig.FallTimeReductionCoefficient;
        _fastFallTimeSeconds *= _difficultyConfig.FallTimeReductionCoefficient;
    }

    public void Dispose()
    {
        _movementController.TetrominoFall -= SpawnRandomTetromino;
    }
}

