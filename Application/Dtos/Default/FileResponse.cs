using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Default
{
    public class FileResponse: BaseResponse<MemoryStream>
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
    }
}
