using TMPro;
using UnityEngine;

namespace UI
{
    public class UIUpdater : MonoBehaviour, IUiUpdater
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text linesText;

        public void UpdateScore(int score)
        {
            scoreText.text = $"{score:D9}";
        }

        public void UpdateLines(int lines)
        {
            linesText.text = $"{lines}";
        }

        public void UpdateLevel(int level)
        {
            levelText.text = $"{level}";
        }
    }
}