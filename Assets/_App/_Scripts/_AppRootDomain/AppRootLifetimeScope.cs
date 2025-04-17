using SuperHomeCare.Tasks;
using SuperHomeCare.TechnicalDebt.TVFP;
using SuperHomeCare.UI.Components;
using SuperHomeCare.UI.Main;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class AppRootLifetimeScope : LifetimeScope
{
    [SerializeField] PawnView pawnView;
    [SerializeField] MainUIView uiView;
    [SerializeField] CreateTaskOpenButtonView creatTaskButtonView;

    [SerializeField] TaskFormView taskFormView;
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
        builder.RegisterInstance(creatTaskButtonView);
        builder.RegisterInstance(taskFormView);
        
        //Controllers LAST
        builder.Register<TaskManagerController>(Lifetime.Scoped);
        builder.Register<TaskFormController>(Lifetime.Scoped);
        builder.RegisterEntryPoint<PawnController>();
        builder.RegisterEntryPoint<MainUIController>();
    }
}
