using MediatR;
using MVCBlogApp.Application.Repositories.Status;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Commands.Status.UpdateStatus
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommandRequest, UpdateStatusCommandResponse>
    {
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IStatusWriteRepository _statusWriteRepository;

        public UpdateStatusCommandHandler(IStatusReadRepository statusReadRepository, IStatusWriteRepository statusWriteRepository)
        {
            _statusReadRepository = statusReadRepository;
            _statusWriteRepository = statusWriteRepository;
        }

        public async Task<UpdateStatusCommandResponse> Handle(UpdateStatusCommandRequest request, CancellationToken cancellationToken)
        {
            E.Status status = await _statusReadRepository.GetByIdAsync(request.Id);

            if (status != null)
            {
                status.StatusName = request.StatusName;

                _statusWriteRepository.Update(status);
                await _statusWriteRepository.SaveAsync();

                return new UpdateStatusCommandResponse() 
                {
                    Message = "Başarıyla güncellendi.",
                    Status = true
                };   
            }
            else
            {
                return new UpdateStatusCommandResponse()
                {
                    Message = "Beklenmedik bir hata ile karşılaşıldı.",
                    Status = false
                };
            }
        }
    }
}
