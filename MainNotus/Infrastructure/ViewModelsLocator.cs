using MainNotus.business.Moduls;
using MainNotus.ViewModels;
using Ninject;

namespace MainNotus.Infrastructure
{
    class ViewModelsLocator
    {
        IKernel kernel;

        public ViewModelsLocator() => kernel = new StandardKernel(new ServiceModule());
        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();
        public AddViewModel AddViewModel => kernel.Get<AddViewModel>();
        public DescriptionViewModel DescriptionViewModel => kernel.Get<DescriptionViewModel>();
    }
}
