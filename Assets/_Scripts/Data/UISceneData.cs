using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Data
{
    [Serializable]
    public class UISceneData
    {
        public TextMeshProUGUI coordinatesText, rotationText, currentSpeedText, laserShotsCountText, laserReloadText;
        public GameObject gameOverScreenUI;
        public TextMeshProUGUI scoreText;
        public Button restartButton;
    }
}