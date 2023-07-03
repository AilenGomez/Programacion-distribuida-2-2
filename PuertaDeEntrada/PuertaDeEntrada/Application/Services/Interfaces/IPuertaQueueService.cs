using PuertaDeEntrada.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using UsersQueueApi.Application.DTOs;

namespace Application.Services
{
    public interface IPuertaQueueService
    {
        Task<TransactionResponse> AddQueue(PuertaEntradaCommand entity, CancellationToken cancellationToken);
    }
}
