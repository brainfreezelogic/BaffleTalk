using Autofac;
using BaffleTalk.Common.Interfaces.Services.Utilities;
using BaffleTalk.Data.Context;
using BaffleTalk.Services.Utilities;

namespace BaffleTalk.Common.IoC
{
    public class BaffleTalkIoCBuilder : ContainerBuilder
    {
        private readonly IContainer _container;

        public BaffleTalkIoCBuilder()
        {
            this.RegisterType<DateTimeService>().As<IDateTimeService>();
            this.RegisterInstance(new BaffleTalkContext());

            _container = Build();
        }

        public IContainer Container
        {
            get { return _container; }
        }
    }
}