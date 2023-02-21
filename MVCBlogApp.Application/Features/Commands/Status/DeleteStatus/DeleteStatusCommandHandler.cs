using MediatR;
using MVCBlogApp.Application.Repositories.Status;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Commands.Status.DeleteStatus
{
    public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommandRequest, DeleteStatusCommandResponse>
    {
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IStatusWriteRepository _statusWriteRepository;

        public DeleteStatusCommandHandler(IStatusReadRepository statusReadRepository, IStatusWriteRepository statusWriteRepository)
        {
            _statusReadRepository = statusReadRepository;
            _statusWriteRepository = statusWriteRepository;
        }

        public async Task<DeleteStatusCommandResponse> Handle(DeleteStatusCommandRequest request, CancellationToken cancellationToken)
        {
            E.Status status = await _statusReadRepository.GetByIdAsync(request.Id);
            if (status != null)
            {
                _statusWriteRepository.Remove(status);
                await _statusWriteRepository.SaveAsync();

                return new() 
                {
                    Message = "Silme işlemi başarılı bir şekilde gerçekleştirildi.",
                    Status = true
                };
            }
            else
            {
                return new()
                {
                    Message = "Silme işlemi sırasında beklenmedik bir hata ile karşılaşıldı.",
                    Status = false
                };
            }
        }
    }
}
