using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.AddProduction
{
    public class AddProductionCommand:IRequest
    {
        public required string Name { get; set; }
        [MaxLength(200)]
        public required string Type { get; set; }
        [MaxLength(100)]
        public required string CompanyName { get; set; }
    }
}
