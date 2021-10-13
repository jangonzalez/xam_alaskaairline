using System;
using System.Collections.Generic;
using System.Reflection;
using AlaskaAir.Core;
using AlaskaAir.Core.Converters;
using Microsoft.Extensions.Logging;
using MvvmCross.Converters;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace AlaskaAir.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override IEnumerable<Assembly> AndroidViewAssemblies =>
            new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(MvxRecyclerView).Assembly
            };

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            registry.AddOrOverwrite(nameof(DateConverter), new DateConverter());
            registry.AddOrOverwrite(nameof(FlightNumberConverter), new FlightNumberConverter());
            base.FillValueConverters(registry);
        }
    }
}
