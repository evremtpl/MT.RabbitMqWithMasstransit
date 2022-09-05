using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.RabbitMq
{
    public class MqConstants
    {
        public static string RabbitMqUri => ConfigurationManager.AppSettings["RabbitMqUri"]; // "rabbitmq://localhost/";

        public static string UserName  => ConfigurationManager.AppSettings["RabbitMqUserName"];// "guest";
        public static string Password  => ConfigurationManager.AppSettings["RabbitMqPassword"]; // "guest";
      
    }
}
