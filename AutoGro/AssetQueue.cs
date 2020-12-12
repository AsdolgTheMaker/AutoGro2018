using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGro
{
    public class AssetQueue : Queue
    {
        public void Enqueue(Asset asset)
        {
            string dir = asset.FullPath.Substring(0, asset.FullPath.LastIndexOf('\\'));
            if (!Directory.Exists(dir)) throw new DirectoryNotFoundException("Directory \"" + dir + "\" was not found.");
            if (!File.Exists(asset.FullPath)) throw new FileNotFoundException();
                
            base.Enqueue(asset);
        }

        public new Asset Dequeue()
        {
            return base.Dequeue() as Asset;
        }
    }
}
