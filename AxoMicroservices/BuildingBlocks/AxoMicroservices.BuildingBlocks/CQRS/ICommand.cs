using MediatR;

namespace AxoMicroservices.BuildingBlocks.CQRS;

public interface ICommand : IRequest
{
    
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}