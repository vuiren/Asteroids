using _Scripts.Data;
using _Scripts.MonoLinks;
using _Scripts.Systems;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class StartUp : MonoBehaviour
    {
        [SerializeField] private Configuration configuration;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameEntitiesBag gameEntitiesBag;
        private IRunSystem[] _runSystems;
        private IStartSystem[] _startSystems;

        // Start is called before the first frame update
        private void Start()
        {
            Setup.Init(configuration, playerInput, _camera, ref gameEntitiesBag, ref _startSystems, ref _runSystems);

            foreach (var startSystem in _startSystems) startSystem.Start();
        }

        // Update is called once per frame
        private void Update()
        {
            foreach (var runSystem in _runSystems) runSystem.Run();
        }
    }
}