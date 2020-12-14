using System;
using Autofac;

namespace ZenMvvm
{
    /// <summary>
    /// Adapts the <see cref="IDiContainer"/> to implement <see cref="IIoc"/>
    /// </summary>
    public class IocAdaptor : IIoc
    {
        internal readonly IContainer container;

        /// <summary>
        /// Construct the <see cref="IocAdaptor"/> from the provided
        ///  see <paramref name="containerBuilder"/>
        /// </summary>
        /// <param name="containerBuilder"></param>
        public IocAdaptor(ContainerBuilder containerBuilder)
        {
            this.container = containerBuilder.Build();
        }

        /// <summary>
        /// Resolves an object from the container
        /// </summary>
        /// <param name="typeToResolve"></param>
        /// <returns></returns>
        public object Resolve(Type typeToResolve)
        {
            return container.Resolve(typeToResolve);
        }
    }
}
