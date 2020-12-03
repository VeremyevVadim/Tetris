using UnityEngine;

namespace Configs.Sound
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/Sound config", order = 6)]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] private string audioClipName;
        [SerializeField] private AudioClip audioClip;

        public string AudioClipName => audioClipName;
        public AudioClip AudioClip => audioClip;
    }
}