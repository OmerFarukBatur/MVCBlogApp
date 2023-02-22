using Microsoft.EntityFrameworkCore;
using MVCBlogApp.Application.Abstractions.Services;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeCreate;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeDelete;
using MVCBlogApp.Application.Features.Commands.BlogType.BlogTypeUpdate;
using MVCBlogApp.Application.Features.Queries.BlogType.GetAllBlogType;
using MVCBlogApp.Application.Features.Queries.BlogType.GetByIdBlogType;
using MVCBlogApp.Application.Repositories.BlogType;
using MVCBlogApp.Application.ViewModels;
using MVCBlogApp.Domain.Entities;

namespace MVCBlogApp.Persistence.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogTypeReadRepository _blogTypeReadRepository;
        private readonly IBlogTypeWriteRepository _blogTypeWriteRepository;

        public BlogService(IBlogTypeReadRepository blogTypeReadRepository, IBlogTypeWriteRepository blogTypeWriteRepository)
        {
            _blogTypeReadRepository = blogTypeReadRepository;
            _blogTypeWriteRepository = blogTypeWriteRepository;
        }

        #region BlogType
        public async Task<BlogTypeCreateCommandResponse> BlogTypeCreateAsync(BlogTypeCreateCommandRequest request)
        {
            var blogType = await _blogTypeReadRepository.GetWhere(x => x.TypeName.Trim().ToLower() == request.TypeName.Trim().ToLower() || x.TypeName.Trim().ToUpper() == request.TypeName.Trim().ToUpper()).ToListAsync();

            if (blogType.Count() > 0)
            {
                return new()
                {
                    Message = "Bu bilgilere sahip bir kayıt bulunmaktadır.",
                    State = false
                };
            }
            else
            {
                BlogType newblogType = new(){ TypeName = request.TypeName };

                await _blogTypeWriteRepository.AddAsync(newblogType);
                await _blogTypeWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Başarıyla kayıt edildi.",
                    State = true
                };
            }
        }

        public async Task<BlogTypeDeleteCommandResponse> BlogTypeDeleteAsync(BlogTypeDeleteCommandRequest request)
        {
            BlogType blogType = await _blogTypeReadRepository.GetByIdAsync(request.Id);

            if (blogType != null)
            {
                _blogTypeWriteRepository.Remove(blogType);
                await _blogTypeWriteRepository.SaveAsync();

                return new()
                {
                    State = true,
                    Message = "Silme işlemi sırasında beklenmedik bir hata ile karşılaşıldı."
                };
            }
            else
            {
                return new()
                {
                    State = false,
                    Message = "Bu bilgilere ait ver bulunmamaktadır.."
                };
            }
        }

        public async Task<BlogTypeUpdateCommandResponse> BlogTypeUpdateAsync(BlogTypeUpdateCommandRequest request)
        {
            BlogType blogType = await _blogTypeReadRepository.GetByIdAsync(request.Id);
            if (blogType != null)
            {
                blogType.TypeName = request.TypeName;
                
                _blogTypeWriteRepository.Update(blogType);
                await _blogTypeWriteRepository.SaveAsync();

                return new()
                {
                    State = true
                };
            }
            else
            {
                return new()
                {
                    State = false
                };
            }
        }

        public async Task<GetAllBlogTypeQueryResponse> GetAllBlogTypeAsync()
        {
            List<VM_BlogType> vM_BlogTypes =  await _blogTypeReadRepository.GetAll().Select(x => new VM_BlogType()
            {
                Id = x.ID,
                TypeName = x.TypeName
            }).ToListAsync();

            return new()
            {
                BlogTypes = vM_BlogTypes
            };
        }

        public async Task<GetByIdBlogTypeQueryResponse> GetByIdBlogTypeAsync(GetByIdBlogTypeQueryRequest request)
        {
            BlogType blogType = await _blogTypeReadRepository.GetByIdAsync(request.Id);

            if (blogType != null)
            {
                return new()
                {
                    BlogType = new() { Id = blogType.ID, TypeName = blogType.TypeName },
                    State = true
                };
            }
            else
            {
                return new()
                {
                    BlogType = null,
                    State = false,
                    Message = "Bu bilgiye sahip bir veri bulunmamaktadır."
                };
            }
        }

        #endregion


    }
}
