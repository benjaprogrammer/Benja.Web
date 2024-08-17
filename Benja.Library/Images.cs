using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Library
{
    public class Images
    {
        public string ToBase64String(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                return "data:image/png;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(imagePath));
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
