using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Entities.UI
{
    [Serializable]
    public class GameOverScreen : GameEntity
    {
        public GameObject gameOverScreenUI;
        public TextMeshProUGUI scoreText;
        public Button restartButton;

        public GameOverScreen(string name = "Game Over Screen") : base(name)
        {
        }
    }
}