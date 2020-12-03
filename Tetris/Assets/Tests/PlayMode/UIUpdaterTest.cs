using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UI;

namespace Tests
{
    public class UIUpdaterTest
    {
        private static (int score, string requiredResult)[] _scoreValues =
        {
            (0, "000000000"),
            (10, "000000010"),
            (1_000, "000001000"),
            (999_999_999, "999999999"),
            (1_000_000_000, "1000000000")
        };
        
        private static (int count, string requiredResult)[] _simpleCounterValues =
        {
            (0, "0"),
            (10, "10"),
            (1_000, "1000"),
            (999_999_999, "999999999"),
            (1_000_000_000, "1000000000")
        };

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(0);
        }

  
        [Test, TestCaseSource(nameof(_scoreValues))]
        public void UpdateScore((int score, string requiredResult) scoreValues)
        {
            var (score, requiredResult) = scoreValues;

            var uiUpdater = GameObject.FindObjectOfType<UIUpdater>();
            var scoreTextGameObject = GameObject.Find("ScoreText");
            var scoreText = scoreTextGameObject.GetComponent<TMP_Text>();
            
            uiUpdater.UpdateScore(score);
            
            Assert.AreEqual(requiredResult, scoreText.text);
        }
        
        [Test, TestCaseSource(nameof(_simpleCounterValues))]
        public void UpdateLines((int lines, string requiredResult) linesValues)
        {
            var (lines, requiredResult) = linesValues;

            var uiUpdater = GameObject.FindObjectOfType<UIUpdater>();
            var linesTextGameObject = GameObject.Find("LinesText");
            var linesText = linesTextGameObject.GetComponent<TMP_Text>();
            
            uiUpdater.UpdateLines(lines);
            
            Assert.AreEqual(requiredResult, linesText.text);
        }
        
        [Test, TestCaseSource(nameof(_simpleCounterValues))]
        public void UpdateLevel((int level, string requiredResult) levelValues)
        {
            var (level, requiredResult) = levelValues;

            var uiUpdater = GameObject.FindObjectOfType<UIUpdater>();
            var levelTextGameObject = GameObject.Find("LevelText");
            var levelText = levelTextGameObject.GetComponent<TMP_Text>();
            
            uiUpdater.UpdateLevel(level);
            
            Assert.AreEqual(requiredResult, levelText.text);
        }
    }
}
