using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace BNZF99_SG1_21_22_2.WpfClient.Infrastructure
{
    class SimpleIocAsServiceLocator : SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }
}
