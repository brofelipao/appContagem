using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContagemApp.Classes
{
    public class ImagesReceiveRequest
    {
        public int? count { get; set; }
        public string? countString { get; set; }
        public string? Image { get; set; }
        public byte[]? ImageByte { get; set; }
        public string path { get; set; }
    }
}
