using Configs.Gameplay;
using NSubstitute;
using Zenject;
using NUnit.Framework;

[TestFixture]
public class GridTest : ZenjectUnitTestFixture
{
    private static (int width, int height)[] _gridConfigValues =
    {
        (0, 0),
        (0, 10),
        (10, 0),
        (10, 10)
    };

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        Container.Bind<IGridConfig>().FromInstance(Substitute.For<IGridConfig>()).AsSingle();
        Container.BindInterfacesAndSelfTo<Grid>().AsSingle().NonLazy();
    }

    [Test, TestCaseSource(nameof(_gridConfigValues))]
    public void InitializeGrid((int width, int height) configValues)
    {
        var gridConfig = Container.Resolve<IGridConfig>();

        var (width, height) = configValues;

        gridConfig.Width.Returns(width);
        gridConfig.Height.Returns(height);
        
        var grid = Container.Resolve<Grid>();
        grid.Initialize();
        
        Assert.AreEqual(grid.Width, gridConfig.Width);
        Assert.AreEqual(grid.Height, gridConfig.Height);
    }
}