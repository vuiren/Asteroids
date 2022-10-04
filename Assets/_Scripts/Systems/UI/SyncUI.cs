using _Scripts.MonoLinks;
using UnityEngine;

namespace _Scripts.Systems.UI
{
    public class SyncUI : IRunSystem
    {
        private readonly Camera _camera;
        private readonly GameEntitiesBag _gameEntitiesBag;

        public SyncUI(GameEntitiesBag gameEntitiesBag, Camera camera)
        {
            _camera = camera;
            _gameEntitiesBag = gameEntitiesBag;
        }

        public void Run()
        {
            if (_gameEntitiesBag.players.Length == 0) return;
            var player = _gameEntitiesBag.players[0];
            if (_gameEntitiesBag.laserWeapons.Length == 0) return;
            var laserWeapon = _gameEntitiesBag.laserWeapons[0];
            var screenPos = _camera.WorldToScreenPoint(player.transform.position);
            foreach (var ui in _gameEntitiesBag.uis)
            {
                ui.coordinatesText.text = "Coords: " + screenPos;
                ui.rotationText.text = "Rotation: " + player.transform.rotation.eulerAngles.z;
                ui.currentSpeedText.text = "Speed: " + player.Velocity.magnitude;
                ui.laserShotsCountText.text = "Laser Shots: " + laserWeapon.remainingLaserShotsCount;
                ui.laserReloadText.text = "Laser Reload: " + laserWeapon.remainingLaserShotReloadTime;
            }
        }
    }
}