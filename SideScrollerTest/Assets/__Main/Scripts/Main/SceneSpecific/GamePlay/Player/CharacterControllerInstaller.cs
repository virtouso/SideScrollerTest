using GamePlay.Elements.Player;
using UnityEngine;
using Zenject;

public class CharacterControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerCharacterControllerModel>().FromMethod(GetModel).AsSingle();
            Container.Bind<PlayerCharacterControllerController>().FromNew().AsSingle();
 
        Container.Bind<IInputMediator>().To<InputMediator>().FromNew().AsSingle();
        Container.Bind<BaseInputReader>().To<WindowsInputReader>().FromNewComponentSibling().AsSingle();

    }

    private PlayerCharacterControllerModel GetModel()
    {
        return GetComponent<PlayerCharacterController>().Model;
    }
}