using UnityEngine;

namespace Gameplay
{
    public class AudioSourcesHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource musicAudioSource;
        [SerializeField] private AudioSource soundAudioSource;
        [SerializeField] private AudioSource gridAudioSource;

        public AudioSource MusicAudioSource => musicAudioSource;
        public AudioSource SoundAudioSource => soundAudioSource;
        public AudioSource GridAudioSource => gridAudioSource;
    }
}