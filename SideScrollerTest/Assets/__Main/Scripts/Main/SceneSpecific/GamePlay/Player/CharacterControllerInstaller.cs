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
        Container.Bind<IActorGroup>().To<CampaignPlayerGroup>().FromComponentSibling().AsSingle();
        Container.Bind<IDamageable>().To<Damageable>().FromComponentSibling().AsSingle();
    }

    private PlayerCharacterControllerModel GetModel()
    {
        return GetComponent<PlayerCharacterController>().Model;
    }
}