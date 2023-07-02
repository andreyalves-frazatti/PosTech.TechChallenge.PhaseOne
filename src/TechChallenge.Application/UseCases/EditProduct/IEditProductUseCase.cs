using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.UseCases.EditProduct
{
    public interface IEditProductUseCase
    {
        Task ExecuteAsync(Product product, CancellationToken cancellation = default);
    }
}
