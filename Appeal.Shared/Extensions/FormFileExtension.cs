using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Shared.Extensions
{
    public static class FormFileExtension
    {
        public static byte[] GetBuffer(this IFormFile file)
        {
            using (var str = new MemoryStream())
            {
                file.CopyTo(str);
                return str.ToArray();
            }
        }
    }
}
