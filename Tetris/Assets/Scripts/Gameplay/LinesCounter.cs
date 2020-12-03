using System;
using UI;
using Zenject;

public class LinesCounter : IInitializable, IValueUpdatable, IDisposable
{
    public event Action OnValueUpdated;

    public int LinesCount { get; private set; }
    public int LastDeletedLinesCount { get; private set; }
    
    private readonly IGrid _grid;
    private readonly IUiUpdater _uiUpdater;

    public LinesCounter(
        IGrid grid,
        IUiUpdater uiUpdater)
    {
        _grid = grid;
        _uiUpdater = uiUpdater;
    }

    public void Initialize()
    {
        _grid.LinesDestroyed += OnLinesDestroyed;
    }
    
    private void OnLinesDestroyed(int linesCount)
    {
        LastDeletedLinesCount = linesCount;
        LinesCount += linesCount;
        
        _uiUpdater.UpdateLines(LinesCount);
        OnValueUpdated?.Invoke();
    }

    public void Dispose()
    {
        _grid.LinesDestroyed -= OnLinesDestroyed;
    }
}