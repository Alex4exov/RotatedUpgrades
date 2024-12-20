using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<StatsController>();
        builder.RegisterComponentInHierarchy<ViewModel>();
    }
}
