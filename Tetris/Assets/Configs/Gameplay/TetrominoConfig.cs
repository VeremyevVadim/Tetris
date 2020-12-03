using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "TetrominoConfig", menuName = "Configs/Tetromino config", order = 1)]
    public class TetrominoConfig : ScriptableObject
    {
        [SerializeField] private float defaultFallTimeSeconds = 0.8f;
        [SerializeField] private float fastFallTimeSeconds = 0.1f;
        
        public float DefaultFallTimeSeconds => defaultFallTimeSeconds;
        public float FastFallTimeSeconds => fastFallTimeSeconds;
    }
}