using Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using PuertaDeEntrada.Application.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using UsersQueueApi.Application.DTOs;

namespace PuertaDeEntrada.Application.Commands
{
    public class PuertaEntradaCommandHandler : IRequestHandler<PuertaEntradaCommand, TransactionResponse>
    {
        private readonly ILogger<PuertaEntradaCommandHandler> _logger;
        private readonly IPuertaQueueService _puertaQueueService;
        public PuertaEntradaCommandHandler(ILogger<PuertaEntradaCommandHandler> logger, IPuertaQueueService puertaQueueService)
        {
            _logger = logger;
            _puertaQueueService = puertaQueueService;
        }

        public async Task<TransactionResponse> Handle(PuertaEntradaCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _puertaQueueService.AddQueue(request, cancellationToken);
            
            return transaction;
        }
    }
}
