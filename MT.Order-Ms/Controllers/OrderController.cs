using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MT.Order_Ms.Models;
using MT.RabbitMq;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace MT.Order_Ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISendEndpoint _sendEndpoint;

        public OrderController()
        {
            var busControl = BusConfigurator.Instance.ConfigureBus();
            var sendToUri = new Uri($"{MqConstants.RabbitMqUri}{MqConstants.OrderQueue}");

            _sendEndpoint = busControl.GetSendEndpoint(sendToUri).Result;
        }


        [HttpPost]
        [Route("createorder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel orderModel)
        {
            // _orderDataAccess.SaveOrder(orderModel);
            _sendEndpoint.Send(orderModel).Wait();
            return Ok("Success");
        }
    }
}
