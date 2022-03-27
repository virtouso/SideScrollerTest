using GamePlay.Elements;
using GamePlay.Elements.Player;
using GamePlay.Manager;
using UnityEngine;
using Utility;
using Zenject;
using CharacterController = UnityEngine.CharacterController;

namespace GamePlay.Installers
{
    public class GamePlayInstaller : MonoInstaller
    {
  
        
        public override void InstallBindings()
        {

            Container.Bind<IUtilitySceneLoader>().To<UtilitySceneLoader>().FromNew().AsSingle();

            Container.Bind<IGamePlayUiManager>().To<GamePlayUiManager>().FromComponentInHierarchy().AsSingle();
      
         }
    }
}