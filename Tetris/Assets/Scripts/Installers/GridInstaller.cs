using Configs;
using Configs.Gameplay;
using UnityEngine;
using Zenject;

public class GridInstaller : MonoInstaller
{
    [SerializeField] private RootConfig rootConfig;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<IGridConfig>().FromInstance(rootConfig.GridConfig).AsSingle();
        Container.BindInterfacesTo<Grid>().AsSingle();
        Container.BindInterfacesAndSelfTo<MovementController>().AsSingle();
    }
}