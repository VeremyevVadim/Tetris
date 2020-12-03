using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "PreviewTetrominoConfig", menuName = "Configs/Preview tetromino config", order = 5)]
    public class PreviewTetrominoConfig : ScriptableObject
    {
        [SerializeField] private float previewTetrominoScale = 2.5f;
        
        public float PreviewTetrominoScale => previewTetrominoScale;
    }
}