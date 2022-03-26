using GamePlay.Elements.Player;
using GamePlay.Manager;
using UnityEngine;
using Zenject;

namespace GamePlay.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacterController _characterController;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerCharacterController>().To<PlayerCharacterController>()
                .FromComponentInNewPrefab(_characterController)
                .AsSingle();


            Container.Bind<ISinglePlayerMissionsManager>().To<SinglePlayerMissionsManager>()
                .FromMethod(FindMissionsManager).AsSingle();
        }

        private SinglePlayerMissionsManager FindMissionsManager()
        {
            return GameObject.FindObjectOfType<SinglePlayerMissionsManager>();
        }
    }
}