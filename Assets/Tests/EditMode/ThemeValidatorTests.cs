using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ThemeValidatorTests
    {
        public Theme.Theme[] Themes { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            Themes = Resources.LoadAll<Theme.Theme>("Themes");
        }

        [Test]
        public void Test_ThemeConfiguration_HighScoreToUnlock_IsLowerThan_TotalScoreToUnlock()
        {
            foreach (var theme in Themes)
            {
                Assert.That(theme.highScoreToUnlock <= theme.totalScoreToUnlock, Is.True, $"{theme}: high score({theme.highScoreToUnlock}) must not be larger than total score({theme.totalScoreToUnlock})");
            }
        }
    }
}