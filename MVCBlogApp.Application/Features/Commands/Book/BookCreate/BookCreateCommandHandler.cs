using MediatR;
using MVCBlogApp.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlogApp.Application.Features.Commands.Book.BookCreate
{
    public class BookCreateCommandHandler : IRequestHandler<BookCreateCommandRequest, BookCreateCommandResponse>
    {
        private readonly IBookService _bookService;

        public BookCreateCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookCreateCommandResponse> Handle(BookCreateCommandRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.BookCreateAsync(request);
        }
    }
}
