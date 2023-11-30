using Microsoft.Extensions.DependencyInjection;

namespace KushalBlogWebApp
{
    /// <summary>
    /// The d i.
    /// </summary>
    public class DI
    {
        private readonly IServiceCollection _serviceCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DI"/> class.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public DI(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

#nullable enable
        private static DI? _instance;
#nullable disable




        /// <summary>
        /// Gets the instance. 
        /// </summary>
        public static DI Instance
        {
            get
            {
                return _instance;
            }
        }



        /// <summary>
        /// Initializes the.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        public static void Initialize(IServiceCollection serviceCollection)
        {
            _instance = new DI(serviceCollection);
        }

        /// <summary>
        /// Gets the resolver.
        /// </summary>
        public ServiceProvider Resolver
        {
            get
            {
                return _serviceCollection.BuildServiceProvider();
            }
        }

        /// <summary>
        /// Resolves the <typeparamref name="T"></typeparamref>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A <typeparamref name="T"></typeparamref></returns>
        public T Resolve<T>()
        {
            return Resolver.GetService<T>();
        }
    }
}
