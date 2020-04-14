using Amazon.SQS;
using Amazon.SQS.Model;
using AmazonSQSSenderAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSQSSenderAPI.Api.Services
{
    public class SqsService : ISqsService
    {
        private readonly IAmazonSQS _amazonSQS;

        public SqsService(IAmazonSQS amazonSQS)
        {
            _amazonSQS = amazonSQS;
        }

        public async Task<SendMessageResponse> SendMessageToSqsQueue(TicketRequest request)
        {
            var sendMessageRequest = new SendMessageRequest()
            {
                QueueUrl = @"https://sqs.us-west-2.amazonaws.com/959393741857/TicketRequest",
                MessageBody = request.Serialize()
            };

            var response = await _amazonSQS.SendMessageAsync(sendMessageRequest);

            return response;
        }
    }
}
