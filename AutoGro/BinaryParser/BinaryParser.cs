using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGro
{
    public static partial class BinaryParser
    {
        public static bool TryParse(string filePath, out List<string> result)
        {
            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)))
            {

            }

            throw new NotImplementedException("TODO: Finish binary parser.");
        }
    }
}