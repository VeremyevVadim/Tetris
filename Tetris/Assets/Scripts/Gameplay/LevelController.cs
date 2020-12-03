using System;
using Configs.Gameplay;
using UI;
using Zenject;

public class LevelController : IInitializable, IDisposable
{
    private readonly DifficultyConfig _difficultyConfig;
    private readonly LinesCounter _linesCounter;
    private readonly IUiUpdater _uiUpdater;

    private readonly IUpgradable[] _upgradableObjects;

    private int _level = 1;
    private int _nextLevelUpBorder;

    public LevelController(
        DifficultyConfig difficultyConfig,
        LinesCounter linesCounter,
        IUpgradable[] upgradableObjects,
        IUiUpdater uiUpdater)
    {
        _difficultyConfig = difficultyConfig;
        _linesCounter = linesCounter;
        _upgradableObjects = upgradableObjects;
        _uiUpdater = uiUpdater;
    }

    public void Initialize()
    {
        _linesCounter.OnValueUpdated += OnLineCountUpdate;

        _nextLevelUpBorder = _level * _difficultyConfig.LinesCompletedToLevelUp;
    }

    private void OnLineCountUpdate()
    {
        while (_linesCounter.LinesCount >= _nextLevelUpBorder)
        {
            foreach (var upgradable in _upgradableObjects)
            {
                upgradable.LevelUp();
            }

            _level++;
            _nextLevelUpBorder = _level * _difficultyConfig.LinesCompletedToLevelUp;

            _uiUpdater.UpdateLevel(_level);
        }
    }

    public void Dispose()
    {
        _linesCounter.OnValueUpdated -= OnLineCountUpdate;
    }
}