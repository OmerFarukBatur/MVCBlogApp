using MediatR;

namespace MVCBlogApp.Application.Features.Queries.File.VideoCategory.GetByIdVideoCategory
{
    public class GetByIdVideoCategoryQueryRequest : IRequest<GetByIdVideoCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}