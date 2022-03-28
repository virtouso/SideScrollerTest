using System;
using GamePlay.Elements;
using GamePlay.Elements.Player;
using GamePlay.Manager;
using General.Configurations;
using UnityEngine;
using Zenject;

namespace GamePlay.Installers
{
    public class CharacterControllerInstaller : MonoInstaller
    {
        [SerializeField] private BuildConfiguration _buildConfig;

        public override void InstallBindings()
        {
            Container.Bind<PlayerCharacterControllerModel>().FromMethod(GetModel).AsSingle();
            Container.Bind<PlayerCharacterControllerController>().FromNew().AsSingle();

            Container.Bind<IInputMediator>().To<InputMediator>().FromNew().AsSingle();


            if (_buildConfig.SelectedController == BuildController.Keyboard)
                Container.Bind<BaseInputReader>().To<WindowsInputReader>().FromNewComponentSibling().AsSingle();
            else
                Container.Bind<BaseInputReader>().To<PlayStationInputReader>().FromNewComponentSibling().AsSingle();


            Container.Bind<IActorGroup>().To<CampaignPlayerGroup>().FromComponentSibling().AsSingle();
            Container.Bind<IDamageable>().To<Damageable>().FromComponentSibling().AsSingle();
            Container.Bind<IInputValidator>().To<InputValidator>().FromNew().AsSingle();
             Container.Bind<IGamePlayUiManager>().To<GamePlayUiManager>().FromMethod(FindUiManager).AsSingle();
         
        }
        private GamePlayUiManager FindUiManager()
        {
            return GameObject.FindObjectOfType<GamePlayUiManager>();
        }

   
        private PlayerCharacterControllerModel GetModel()
        {
            return GetComponent<PlayerCharacterController>().Model;
        }
    }
}