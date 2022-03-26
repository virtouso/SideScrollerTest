using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace MainMenu.Panels
{


    public class MainMenuMainPanelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MainMenuMainPanelModel>().FromNew().AsSingle();
            Container.Bind<MainMenuMainPanelController>().FromNew().AsSingle();
            Container.Bind<MainMenuMainPanel>().FromComponentSibling().AsSingle();
        }
    }
}