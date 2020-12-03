using System.Collections.Generic;
using Configs.Sound;
using Gameplay;
using UnityEngine;
using Zenject;

public class SoundService : ISoundService, IInitializable
{
    private readonly GameplaySoundGroupConfig _gameplaySoundGroupConfig;
    private readonly AudioSourcesHandler _audioSourcesHandler;

    private Dictionary<string, AudioClip> _sounds;
    
    public SoundService(
        GameplaySoundGroupConfig gameplaySoundGroupConfig,
        AudioSourcesHandler audioSourcesHandler)
    {
        _gameplaySoundGroupConfig = gameplaySoundGroupConfig;
        _audioSourcesHandler = audioSourcesHandler;
    }
    
    public void Initialize()
    {
        var soundConfigs = _gameplaySoundGroupConfig.SoundConfigs;
        
        _sounds = new Dictionary<string, AudioClip>();
        foreach (var config in soundConfigs)
        {
            _sounds.Add(config.AudioClipName, config.AudioClip);
        }

        _audioSourcesHandler.MusicAudioSource.loop = true;
        _audioSourcesHandler.SoundAudioSource.loop = false;
        _audioSourcesHandler.GridAudioSource.loop = false;
        
        PlayBackgroundSound();
    }

    public void PlayBackgroundSound()
    {
        _audioSourcesHandler.MusicAudioSource.clip = _sounds["BackgroundMusic"];
        _audioSourcesHandler.MusicAudioSource.Play();
    }

    public void PlayDropSound()
    {
        _audioSourcesHandler.GridAudioSource.clip = _sounds["Drop"];
        _audioSourcesHandler.GridAudioSource.Play();
    }

    public void PlayRotateSound()
    {
        _audioSourcesHandler.SoundAudioSource.clip = _sounds["Rotate"];
        _audioSourcesHandler.SoundAudioSource.Play();
    }

    public void PlayMoveSound()
    {
        _audioSourcesHandler.SoundAudioSource.clip = _sounds["Move"];
        _audioSourcesHandler.SoundAudioSource.Play();
    }
}
