using UnityEngine;
using Utility;
using Zenject;

namespace MainMenu.Installers
{
    
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUtilitySceneLoader>().To<UtilitySceneLoader>().FromNew().AsSingle();


        }
    }
}