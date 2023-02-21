using MediatR;
using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Repositories.Status;
using E = MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Application.Features.Commands.Status.CreateStatus
{
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommandRequest, CreateStatusCommandResponse>
    {
        private readonly IStatusReadRepository _statusReadRepository;
        private readonly IStatusWriteRepository _statusWriteRepository;

        public CreateStatusCommandHandler(IStatusReadRepository statusReadRepository, IStatusWriteRepository statusWriteRepository)
        {
            _statusReadRepository = statusReadRepository;
            _statusWriteRepository = statusWriteRepository;
        }

        public async Task<CreateStatusCommandResponse> Handle(CreateStatusCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.StatusName != "")
            {
                var allStatus = await _statusReadRepository.GetWhere(a => a.StatusName.Trim().ToUpper() == request.StatusName || a.StatusName.Trim().ToLower() == request.StatusName).ToListAsync();
                if (allStatus.Count() == 0)
                {
                    E.Status status = new()
                    {
                        StatusName = request.StatusName
                    };

                    await _statusWriteRepository.AddAsync(status);
                    await _statusWriteRepository.SaveAsync();

                    return new()
                    {
                        Status = true,
                        Message = "Başarılı bir şekilde kayıt edildi."
                    };

                }
                else
                {
                    return new()
                    {
                        Status = false,
                        Message = "Bu bilgilere ait bir kayıt bulunmaktadır."
                    };
                }
            }
            else
            {
                return new()
                {
                    Status = false,
                    Message = "Lütfen geçerli veriler giriniz."
                };
            }
        }
    }
}
