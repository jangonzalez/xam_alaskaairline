using System;
using System.Globalization;
using Acr.UserDialogs;
using Microsoft.Extensions.Logging;
using Moq;
using MvvmCross.Base;
using MvvmCross.Binding;
using MvvmCross.Core;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.Views;
using Services.Implementations.API;
using Services.Interfaces;

namespace AlaskaAir.Tests
{
    public class MvxIoCSupportingTest
    {
        public IMvxIoCProvider Ioc { get; private set; }

        public MvxIoCSupportingTest()
        {
            Setup();
        }

        public void Setup()
        {
            ClearAll();
        }

        public void Reset()
        {
            MvxSingleton.ClearAllSingletons();
            Ioc = null;
        }

        protected virtual IMvxIocOptions CreateIocOptions()
        {
            return null;
        }

        public virtual void ClearAll(IMvxIocOptions options = null)
        {
            // fake set up of the IoC
            Reset();
            Ioc = MvxIoCProvider.Initialize(options ?? CreateIocOptions());
            Ioc.RegisterSingleton(Ioc);

            InitializeSingletonCache();
            InitializeMvxSettings();
            AdditionalSetup();
        }

        public void InitializeSingletonCache()
        {
            if (MvxSingletonCache.Instance == null)
                MvxSingletonCache.Initialize();

            if (MvxBindingSingletonCache.Instance == null)
                MvxBindingSingletonCache.Initialize();
        }

        protected virtual void InitializeMvxSettings()
        {
            Ioc.RegisterSingleton<IMvxSettings>(new MvxSettings());
        }

        protected virtual void AdditionalSetup()
        {
            //mock dispatcher for UI
            var mockDispatcher = new NavigationMockDispatcher();

            //register services
            var logger = new Mock<ILoggerFactory>();
            var navigation = new Mock<IMvxNavigationService>();
            var flightService = new FlightSearchAPIService();//new Mock<IFlightSearchService>();
            var dialogs = new Mock<IUserDialogs>();

            Ioc.RegisterSingleton<IMvxViewDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(mockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadAsyncDispatcher>(mockDispatcher);

            Ioc.RegisterSingleton<IUserDialogs>(dialogs.Object);
            Ioc.RegisterSingleton<IFlightSearchService>(flightService);
            Ioc.RegisterSingleton<ILoggerFactory>(logger.Object);
            Ioc.RegisterSingleton<IMvxNavigationService>(navigation.Object);
        }

        public void SetInvariantCulture()
        {
            var invariantCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentCulture = invariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = invariantCulture;
        }
    }
}
