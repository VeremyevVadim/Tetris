using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Configs/Grid config", order = 3)]
    public class GridConfig : ScriptableObject, IGridConfig
    {
        [SerializeField] private int width = 10;
        [SerializeField] private int height = 20;

        public int Width => width;
        public int Height => height;
    }

    public interface IGridConfig
    {
        int Width { get; }
        int Height { get; }
    }
}