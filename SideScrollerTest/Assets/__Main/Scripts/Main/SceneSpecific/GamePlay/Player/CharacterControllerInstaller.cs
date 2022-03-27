using GamePlay.Elements;
using GamePlay.Elements.Player;
using GamePlay.Manager;
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
        Container.Bind<IInputValidator>().To<InputValidator>().FromNew().AsSingle();
        // Container.Bind<IGamePlayUiManager>().To<GamePlayUiManager>().FromMethod(FindUiManager).AsSingle();
        // Container.Bind<ISinglePlayerMissionsManager>().To<SinglePlayerMissionsManager>().FromMethod(FindMissionsManager)
        //     .AsSingle();
    }

    // private GamePlayUiManager FindUiManager()
    // {
    //     return GameObject.FindObjectOfType<GamePlayUiManager>();
    // }

    // private SinglePlayerMissionsManager FindMissionsManager()
    // {
    //     return GameObject.FindObjectOfType<SinglePlayerMissionsManager>();
    // }
    //
    private PlayerCharacterControllerModel GetModel()
    {
        return GetComponent<PlayerCharacterController>().Model;
    }
}