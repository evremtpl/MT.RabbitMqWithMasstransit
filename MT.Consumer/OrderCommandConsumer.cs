﻿using MassTransit;
using MT.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Consumer
{
    public class OrderCommandConsumer : IConsumer<IOrderCommand>
    {
        public async Task Consume(ConsumeContext<IOrderCommand> context)
        {
            var orderCommand = context.Message;

            await Console.Out.WriteAsync($"Order Code : {orderCommand.OrderCode} " +
                $"OrderId: {orderCommand.OrderID}");
        }
    }
}
