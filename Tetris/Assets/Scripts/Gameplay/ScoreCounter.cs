using System;
using System.Collections.Generic;
using Configs.Gameplay;
using UI;
using Zenject;

public class ScoreCounter : IInitializable, IDisposable
{
    private readonly LinesRewardConfig _linesRewardConfigConfig;
    private readonly LinesCounter _linesCounter;
    private readonly IUiUpdater _uiUpdater;
    
    private readonly Dictionary<int, int> _rewards = new Dictionary<int, int>();
    private int _score;
    

    public ScoreCounter(
        LinesRewardConfig linesRewardConfig,
        LinesCounter linesCounter,
        IUiUpdater uiUpdater)
    {
        _linesRewardConfigConfig = linesRewardConfig;
        _linesCounter = linesCounter;
        _uiUpdater = uiUpdater;
    }
    
    public void Initialize()
    {
        _linesCounter.OnValueUpdated += OnUpdatedCallback;
        
        _rewards.Add(1, _linesRewardConfigConfig.OneLineReward);
        _rewards.Add(2, _linesRewardConfigConfig.TwoLineReward);
        _rewards.Add(3, _linesRewardConfigConfig.ThreeLineReward);
        _rewards.Add(4, _linesRewardConfigConfig.FourLineReward);
    }
    
    private void OnUpdatedCallback()
    {
        _score += _rewards[_linesCounter.LastDeletedLinesCount];
        _uiUpdater.UpdateScore(_score);
    }

    public void Dispose()
    {
        _linesCounter.OnValueUpdated -= OnUpdatedCallback;
    }
}

