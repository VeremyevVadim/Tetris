using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "DifficultyConfig", menuName = "Configs/Difficulty settings", order = 2)]
    public class DifficultyConfig : ScriptableObject
    {
        [SerializeField] private int linesCompletedToLevelUp = 4;
        [SerializeField] private float fallTimeReductionCoefficient = 0.8f;

        public int LinesCompletedToLevelUp => linesCompletedToLevelUp;
        public float FallTimeReductionCoefficient => fallTimeReductionCoefficient;
    }
}