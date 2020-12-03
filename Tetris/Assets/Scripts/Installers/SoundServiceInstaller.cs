using Configs.Gameplay;
using Configs.Sound;
using Gameplay;
using UnityEngine;
using Zenject;

public class SoundServiceInstaller : MonoInstaller
{
    [SerializeField] private RootConfig rootConfig;
    [SerializeField] private AudioSourcesHandler audioSourcesHandler;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<SoundService>().AsSingle();
        Container.Bind<GameplaySoundGroupConfig>().FromInstance(rootConfig.GameplaySoundGroupConfig);
        Container.Bind<AudioSourcesHandler>().FromInstance(audioSourcesHandler);
    }
}