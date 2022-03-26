using GamePlay.Elements;
using GamePlay.Elements.Player;
using GamePlay.Manager;
using UnityEngine;
using Zenject;
using CharacterController = UnityEngine.CharacterController;

namespace GamePlay.Installers
{
    public class GamePlayInstaller : MonoInstaller
    {
  
        
        public override void InstallBindings()
        {
            // Container.Bind<ISinglePlayerMissionsManager>().To<SinglePlayerMissionsManager>()
            //     .FromComponentInHierarchy()
            //     .AsSingle();


            Container.Bind<IGamePlayUiManager>().To<GamePlayUiManager>().FromComponentInHierarchy().AsSingle();
        //     Container.Bind<ISinglePlayerMissionsManager>().To<SinglePlayerMissionsManager>().FromComponentsInHierarchy()
        //         .AsSingle();
         }
    }
}