using UnityEngine;

namespace Configs.Gameplay
{
    [CreateAssetMenu(fileName = "AnimationConfig", menuName = "Configs/Animation config", order = 8)]
    public class AnimationConfig : ScriptableObject
    {
        [SerializeField] private float panelToggleDurationSeconds = 0.5f;

        public float PanelToggleDurationSeconds => panelToggleDurationSeconds;
    }
}