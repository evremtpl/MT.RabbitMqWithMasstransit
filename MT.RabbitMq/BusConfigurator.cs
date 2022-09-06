using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.RabbitMq
{
    public class BusConfigurator
    {
        private static readonly Lazy<BusConfigurator> _Instance = new Lazy<BusConfigurator>(() => new BusConfigurator());

        public BusConfigurator()
        {

        }
        public static BusConfigurator Instance=> _Instance.Value;
        public  IBusControl ConfigureBus( Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost>
  registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(MqConstants.RabbitMqUri), hst =>
                {
                    hst.Username(MqConstants.UserName);
                    hst.Password(MqConstants.Password);
                });

                

                registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
