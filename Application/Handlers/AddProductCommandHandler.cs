using Core.Commands;
using Core.Entities;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Handlers
{
    public class AddProductCommandHandler:IRequestHandler<AddProductCommand,bool>
    {
        private readonly IProductRepository _repository;

        public AddProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public  async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { ProductId = request.Id, Name = request.Name, Price = request.Price };
            await _repository.AddProductAsync(product);
            return true;
        }

       
    }
}
