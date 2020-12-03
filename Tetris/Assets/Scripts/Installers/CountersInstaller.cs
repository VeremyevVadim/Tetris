using Configs.Gameplay;
using UI;
using UnityEngine;
using Zenject;

public class CountersInstaller : MonoInstaller
{
    [SerializeField] private RootConfig rootConfig;
    [SerializeField] private UIUpdater uiUpdater;

    public override void InstallBindings()
    {
        Container.Bind<DifficultyConfig>().FromInstance(rootConfig.DifficultyConfig).AsSingle();
        Container.Bind<TetrominoConfig>().FromInstance(rootConfig.TetrominoConfig).AsSingle();
        Container.Bind<LinesRewardConfig>().FromInstance(rootConfig.LinesRewardConfig).AsSingle();

        Container.Bind<IUiUpdater>().FromInstance(uiUpdater).AsSingle();

        Container.BindInterfacesAndSelfTo<LinesCounter>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle().NonLazy();
        Container.BindInterfacesTo<LevelController>().AsSingle().NonLazy();
    }
}