using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Acudir.Challenge.DTOs.Common
{
    public class ErrorDetailsDTO
    {
        public int? StatusCode { get; set; }
        public String? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
