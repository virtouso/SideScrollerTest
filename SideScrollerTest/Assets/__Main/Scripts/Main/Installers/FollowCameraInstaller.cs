using GamePlay.Elements;
using Mvc;
using UnityEngine;
using Zenject;

namespace MainMenu.Installers
{
    
    public class FollowCameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Container.Bind<BaseController<FollowCameraModel>>().To<FollowCameraController>().FromNew()
            //     .AsSingle();
            //
            // Container.Bind<BaseModel>().To<FollowCameraModel>().FromNew().AsSingle();
            //
            // Container.Bind<BaseView<FollowCameraModel, FollowCameraController>>().To<FollowCamera>()
            //     .FromComponentSibling().AsSingle();

            
            
            Container.Bind<FollowCameraController>().FromNew()
                .AsSingle();

            Container.Bind<FollowCameraModel>().FromNew().AsSingle();

            Container.Bind<FollowCamera>()
                .FromComponentSibling().AsSingle();
            

        }
    }
}