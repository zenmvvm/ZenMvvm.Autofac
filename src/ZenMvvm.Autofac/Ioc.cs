using System;
using Autofac;
using Autofac.Builder;

namespace ZenMvvm
{
    /// <summary>
    /// Utility to initialize the container and set the <see cref="ViewModelLocator.Ioc"/>
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// Returns a <see cref="Autofac.IContainer"/>
        /// </summary>
        public static IContainer Container { get; internal set; }

        /// <summary>
        /// Initializes the <see cref="ViewModelLocator"/> with the given
        ///  <paramref name="containerBuilder"/> and registers <see cref="INavigationService"/>
        ///  for Mvvm navigation.
        /// </summary>
        /// <param name="containerBuilder"></param>
        public static void Init(ContainerBuilder containerBuilder, ContainerBuildOptions options = ContainerBuildOptions.None)
        {
            containerBuilder
                .RegisterType<NavigationService>()
                .As<INavigationService>()
                .UsingConstructor(Type.EmptyTypes);

            var iocAdaptor = new IocAdaptor(containerBuilder, options);
            Container = iocAdaptor.container;
            ViewModelLocator.Ioc = iocAdaptor;
        }        
    }
}
