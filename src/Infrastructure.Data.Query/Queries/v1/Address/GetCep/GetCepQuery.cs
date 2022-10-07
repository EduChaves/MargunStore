using MediatR;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Address.GetCep
{
    public class GetCepQuery : IRequest<GetCepQueryResponse>
    {
        public string Cep { get; set; }
    }
}
