namespace UI
{
    public interface IUiUpdater
    {
        void UpdateScore(int score);
        void UpdateLines(int lines);
        void UpdateLevel(int levels);
    }
}