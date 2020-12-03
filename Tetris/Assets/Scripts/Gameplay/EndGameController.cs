using System;
using Configs.Gameplay;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Zenject;
using Vector3 = UnityEngine.Vector3;

public class EndGameController : IInitializable, IDisposable
{
    private readonly EndGamePopUpHandler _endGamePopUpHandler;
    private readonly IGrid _grid;
    private readonly TetrominoSpawner _tetrominoSpawner;
    private readonly MovementController _movementController;
    private readonly AnimationConfig _animationConfig;
    
    private float _animationDuration = 0.5f;

    public EndGameController(
        EndGamePopUpHandler endGamePopUpHandler,
        IGrid grid,
        TetrominoSpawner tetrominoSpawner,
        MovementController movementController,
        AnimationConfig animationConfig)
    {
        _endGamePopUpHandler = endGamePopUpHandler;
        _grid = grid;
        _tetrominoSpawner = tetrominoSpawner;
        _movementController = movementController;
        _animationConfig = animationConfig;
    }

    public void Initialize()
    {
        _grid.EndGame += OnEndGame;

        _endGamePopUpHandler.Panel.transform.localScale *= 0;
        _endGamePopUpHandler.Panel.SetActive(false);

        _endGamePopUpHandler.ReplayButton.enabled = false;
        _endGamePopUpHandler.ReplayButton.onClick.AddListener(OnReplayButtonClick);
    }

    private void OnEndGame()
    {
        _tetrominoSpawner.Dispose();
        _movementController.Dispose();

        _endGamePopUpHandler.Panel.SetActive(true);

        var sequence = DOTween.Sequence();
        sequence.Append(_endGamePopUpHandler.Panel.transform.DOScale(Vector3.one, _animationDuration));
        sequence.onComplete += () => { _endGamePopUpHandler.ReplayButton.enabled = true; };
    }

    private void OnReplayButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Dispose()
    {
        _grid.EndGame -= OnEndGame;
    }
}