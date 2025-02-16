using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Default
{
    public class DataResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public void AddError(string error) => Errors.Add(error);
        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);
        public bool Success { get; set; }
    }
}
