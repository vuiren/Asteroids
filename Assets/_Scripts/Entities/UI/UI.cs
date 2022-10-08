using System;
using TMPro;

namespace _Scripts.Entities.UI
{
    [Serializable]
    public class UI : GameEntity
    {
        public TextMeshProUGUI coordinatesText, rotationText, currentSpeedText, laserShotsCountText, laserReloadText;

        public UI(string name = "UI") : base(name)
        {
        }
    }
}