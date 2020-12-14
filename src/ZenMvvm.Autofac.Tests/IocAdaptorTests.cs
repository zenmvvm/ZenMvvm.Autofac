using Xunit;
using Autofac;

// Note - Autofac uses sealed classes which make mocking with Moq impossible
// therefore tests are also testing Autofac code
namespace ZenMvvm.Autofac.Tests
{
    public class IocAdaptorTests
    {
        [Fact]
        public void Constructor_SetsContainer()
        {
            var adaptor = new IocAdaptor(new ContainerBuilder());

            Assert.NotNull(adaptor.container);
        }

        [Fact]
        public void Resolve_CallsContainerResolve()
        {
            var testObject = new object();
            var builder = new ContainerBuilder();
            builder.RegisterInstance(testObject);
            var adaptor = new IocAdaptor(builder);

            Assert.Equal(testObject, adaptor.Resolve(typeof(object)));
        }
    }
}
