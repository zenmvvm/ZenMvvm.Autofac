using Autofac;
using Xunit;

// Note - Autofac uses sealed classes which make mocking with Moq impossible
// therefore tests are also testing Autofac code
namespace ZenMvvm.Autofac.Tests
{

    public class IocTests
    {
        [Fact]
        public void Init_SetsContainer()
        {
            Ioc.Container = null;
            Ioc.Init(new ContainerBuilder());

            Assert.NotNull(Ioc.Container);
        }

        [Fact]
        public void Init_SetsViewModelLocatorIoc()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;

            Ioc.Init(new ContainerBuilder());

            Assert.NotNull(ViewModelLocator.Ioc);
        }


        [Fact]
        public void Init_Registers_INavigationService()
        {
            Ioc.Container = null;
            ViewModelLocator.Ioc = null;
            var builder = new ContainerBuilder();

            Ioc.Init(builder);

            Assert.IsType<NavigationService>(Ioc.Container.Resolve(typeof(INavigationService)));
        }
    }
}
