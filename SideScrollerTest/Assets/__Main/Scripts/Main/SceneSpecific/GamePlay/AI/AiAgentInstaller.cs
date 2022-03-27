using UnityEngine;
using Zenject;

public class AiAgentInstaller : MonoInstaller
{
    public override void InstallBindings()
    {

        Container.Bind<IActorGroup>().To<CampaignEnemyGroup>().FromComponentSibling().AsSingle();
        Container.Bind<IDamageable>().To<Damageable>().FromComponentSibling().AsSingle();
    }
}