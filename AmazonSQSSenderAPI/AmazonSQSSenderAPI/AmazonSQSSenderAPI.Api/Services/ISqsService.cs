using Amazon.SQS.Model;
using AmazonSQSSenderAPI.Api.Models;
using System.Threading.Tasks;

namespace AmazonSQSSenderAPI.Api.Services
{
    public interface ISqsService
    {
        Task<SendMessageResponse> SendMessageToSqsQueue(TicketRequest request);
    }
}
