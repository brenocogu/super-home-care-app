using SuperHomeCare.Tasks;
using SuperHomeCare.TechnicalDebt.TVFP;
using SuperHomeCare.UI;
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
    [SerializeField] TodoListView todoListView;
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
        builder.RegisterInstance(todoListView);
        
        //Controllers LAST
        builder.UseEntryPoints(entryPoints =>
        {
            entryPoints.Add<PawnController>();
            entryPoints.Add<TaskManagerController>().AsSelf();
            entryPoints.Add<TaskFormController>().AsSelf();
            entryPoints.Add<TodoListController>().AsSelf();
            entryPoints.Add<MainUIController>().AsSelf();
        });
    }
}
