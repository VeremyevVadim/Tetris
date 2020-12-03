using Configs.Gameplay;
using UnityEngine;
using Zenject;

public class PreviewTetrominoSpawner : MonoBehaviour
{
    [SerializeField] private Transform previewTetrominoPoint;

    private PreviewTetrominoConfig _previewTetrominoConfig;
    private TetrominoSpawner _tetrominoSpawner;

    private float _scale;
    private Tetromino _previewedTetromino;

    [Inject]
    public void Construct(PreviewTetrominoConfig previewTetrominoConfig, TetrominoSpawner tetrominoSpawner)
    {
        _previewTetrominoConfig = previewTetrominoConfig;
        _tetrominoSpawner = tetrominoSpawner;
    }
    
    private void Awake()
    {
        _tetrominoSpawner.OnPreviewTetrominoUpdated += UpdatePreview;
        _scale = _previewTetrominoConfig.PreviewTetrominoScale;
    }

    private void OnDestroy()
    {
        _tetrominoSpawner.OnPreviewTetrominoUpdated -= UpdatePreview;
    }

    private void UpdatePreview(Tetromino previewTetromino)
    {
        if (_previewedTetromino != null)
        {
            Destroy(_previewedTetromino.gameObject);
        }
        
        _previewedTetromino = Instantiate(previewTetromino, previewTetrominoPoint.position, Quaternion.identity);
        _previewedTetromino.gameObject.transform.localScale *= _scale;
        _previewedTetromino.enabled = false;
    }
}