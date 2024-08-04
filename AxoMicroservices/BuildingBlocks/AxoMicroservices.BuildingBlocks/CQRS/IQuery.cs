using MediatR;

namespace AxoMicroservices.BuildingBlocks.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{

}