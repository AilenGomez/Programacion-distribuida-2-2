using MediatR;
using System.ComponentModel.DataAnnotations;
using UsersQueueApi.Application.DTOs;

namespace PuertaDeEntrada.Application.Commands
{
    public class PuertaEntradaCommand : IRequest<TransactionResponse>
    {
        [EmailAddress]
        public string email { get; set; }
    }
}
