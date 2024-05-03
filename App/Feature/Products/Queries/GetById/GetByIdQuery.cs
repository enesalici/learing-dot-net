using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Feature.Products.Queries.GetById
{
    public class GetByIdQuery : IRequest<>
    {
        public int Id { get; set; }
    }
}
