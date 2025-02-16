
namespace BeoRecruitment.Services
{
    public class ViewLocator : IViewLocator
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly Dictionary<Type, Type> _registeredViews = [];

        public ViewLocator(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public IViewLocator RegisterView<TViewModel, TView>()
            where TViewModel : class
            where TView : Page
        {
            _registeredViews[typeof(TViewModel)] = typeof(TView);
            _serviceCollection.AddTransient<TViewModel>();
            _serviceCollection.AddTransient<TView>();

            return this;
        }

        public Type LocateView<TViewModel>()
        {
            if (_registeredViews.TryGetValue(typeof(TViewModel), out var viewType))
            {
                return viewType;
            }

            throw new ArgumentOutOfRangeException(nameof(TViewModel), $@"Please register {typeof(TViewModel)} with the IoC");
        }
    }

    public static class ViewLocatorExtensions
    {
        private static IViewLocator? _viewLocator = null;

        public static MauiAppBuilder UseViewLocater(this MauiAppBuilder builder)
        {
            if (_viewLocator is not null)
            {
                throw new InvalidOperationException($@"Please only call {nameof(UseViewLocater)} once");
            }

            builder.Services.AddSingleton(_viewLocator = new ViewLocator(builder.Services));
            return builder;
        }

        public static IServiceCollection RegisterView<TViewModel, TView>(this IServiceCollection services)
            where TViewModel : class
            where TView : Page
        {
            if (_viewLocator is null)
            {
                throw new InvalidOperationException($@"Please call {nameof(UseViewLocater)} first");
            }
            _viewLocator.RegisterView<TViewModel, TView>();

            return services;
        }
    }
}

