using SuperHomeCare.Tasks;
using SuperHomeCare.TechnicalDebt.TVFP;
using SuperHomeCare.UI.Main;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class AppRootLifetimeScope : LifetimeScope
{
    [SerializeField] PawnView pawnView;
    [SerializeField] MainUIView uiView;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    protected override void Configure(IContainerBuilder builder)
    {
        //Models FIRST
        builder.Register<TaskManagerModel>(Lifetime.Scoped);
        
        //Views Second
        builder.RegisterInstance(pawnView);
        builder.RegisterInstance(uiView);
        
        //Controllers LAST
        builder.Register<TaskManagerController>(Lifetime.Scoped);
        builder.RegisterEntryPoint<PawnController>();
        builder.RegisterEntryPoint<MainUIController>();
    }
}
