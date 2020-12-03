using Configs.Gameplay;
using UnityEngine;
using Zenject;

public class EndGameControllerInstaller : MonoInstaller
{
    [SerializeField] private EndGamePopUpHandler endGamePopUpHandler;
    [SerializeField] private RootConfig rootConfig;
    
    public override void InstallBindings()
    {
        Container.Bind<AnimationConfig>().ToSelf().FromInstance(rootConfig.AnimationConfig).AsSingle();
        Container.Bind<EndGamePopUpHandler>().ToSelf().FromInstance(endGamePopUpHandler).AsSingle();
        Container.BindInterfacesAndSelfTo<EndGameController>().AsSingle().NonLazy();
    }
}