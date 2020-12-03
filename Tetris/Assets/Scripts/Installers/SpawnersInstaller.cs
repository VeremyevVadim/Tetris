using Configs.Gameplay;
using UnityEngine;
using Zenject;

public class SpawnersInstaller : MonoInstaller
{
    [SerializeField] private TetrominoSpawner tetrominoSpawner;
    [SerializeField] private RootConfig rootConfig;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TetrominoSpawner>().FromInstance(tetrominoSpawner).AsSingle();
        Container.BindInterfacesTo<TetrominoLoader>().AsSingle();
        Container.Bind<PreviewTetrominoConfig>().ToSelf().FromInstance(rootConfig.PreviewTetrominoConfig).AsSingle();
    }
}