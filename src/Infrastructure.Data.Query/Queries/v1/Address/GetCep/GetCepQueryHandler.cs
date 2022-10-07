using AutoMapper;
using MargunStore.Infrastructure.Service.Interfaces.CorreiosApi;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MargunStore.Infrastructure.Data.Query.Queries.v1.Address.GetCep
{
    public class GetCepQueryHandler : IRequestHandler<GetCepQuery,GetCepQueryResponse>
    {
        private readonly ICorreiosService _service;
        private readonly IMapper _mapper;

        public GetCepQueryHandler(ICorreiosService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<GetCepQueryResponse> Handle(GetCepQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.FindLocation(request.Cep);
            return _mapper.Map<GetCepQueryResponse>(response);
        }
    }
}
