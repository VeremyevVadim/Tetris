using System.Collections.Generic;
using UnityEngine;

namespace Configs.Sound
{
    [CreateAssetMenu(fileName = "GameplaySoundGroup", menuName = "Configs/Gameplay sound group", order = 7)]
    public class GameplaySoundGroupConfig : ScriptableObject
    {
        [SerializeField] private SoundConfig[] soundConfigs;

        public IEnumerable<SoundConfig> SoundConfigs => soundConfigs;
    }
}