using GamePlay.Elements.Player;
using GamePlay.Manager;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace GamePlay.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacterController _characterController;
        [SerializeField] private int _poolSize;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private EnvironmentInteractionConfiguration _environmentConfig;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerCharacterController>().To<PlayerCharacterController>()
                .FromComponentInNewPrefab(_characterController)
                .AsSingle();


            Container.Bind<ISinglePlayerMissionsManager>().To<SinglePlayerMissionsManager>()
                .FromMethod(FindMissionsManager).AsSingle();

            Container.BindMemoryPool<IBullet, IBullet.Pool>().WithInitialSize(_poolSize)
                .FromComponentInNewPrefab(_bulletPrefab).AsTransient();
            Container.Bind<IEnvironmentInteractionManager>().To<EnvironmentInteractionManager>()
                .FromComponentInHierarchy().AsSingle();

            Container.Bind<IEnvironmentInteractionConfiguration>().To<EnvironmentInteractionConfiguration>()
                .FromScriptableObject(_environmentConfig).AsSingle();
        }

        private SinglePlayerMissionsManager FindMissionsManager()
        {
            return GameObject.FindObjectOfType<SinglePlayerMissionsManager>();
        }
    }
}