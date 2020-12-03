using Configs.Sound;
using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "RootConfig", menuName = "Configs/Root config", order = 10)]
    public class RootConfig : ScriptableObject
    {
        [SerializeField] private DifficultyConfig difficultyConfig;
        [SerializeField] private GridConfig gridConfig;
        [SerializeField] private LinesRewardConfig linesRewardConfig;
        [SerializeField] private TetrominoConfig tetrominoConfig;
        [SerializeField] private PreviewTetrominoConfig previewTetrominoConfig;
        [SerializeField] private GameplaySoundGroupConfig gameplaySoundGroupConfig;
        [SerializeField] private AnimationConfig animationConfig;

        public DifficultyConfig DifficultyConfig => difficultyConfig;
        public GridConfig GridConfig => gridConfig;
        public LinesRewardConfig LinesRewardConfig => linesRewardConfig;
        public TetrominoConfig TetrominoConfig => tetrominoConfig;
        public PreviewTetrominoConfig PreviewTetrominoConfig => previewTetrominoConfig;
        public GameplaySoundGroupConfig GameplaySoundGroupConfig => gameplaySoundGroupConfig;
        public AnimationConfig AnimationConfig => animationConfig;
    }
}