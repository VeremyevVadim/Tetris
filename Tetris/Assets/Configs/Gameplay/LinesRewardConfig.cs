using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "LineRewardConfig", menuName = "Configs/Lines reward", order = 0)]
    public class LinesRewardConfig : ScriptableObject
    {
        [SerializeField] private int oneLineReward = 40;
        [SerializeField] private int twoLineReward = 100;
        [SerializeField] private int threeLineReward = 200;
        [SerializeField] private int fourLineReward = 400;

        public int OneLineReward => oneLineReward;
        public int TwoLineReward => twoLineReward;
        public int ThreeLineReward => threeLineReward;
        public int FourLineReward => fourLineReward;
    }
}