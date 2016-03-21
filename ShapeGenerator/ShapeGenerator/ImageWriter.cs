using System.Configuration;
using System.Drawing;
using System.IO;

namespace ShapeGenerator
{
    public class ImageWriter
    {
        private readonly string outputDir;

        public ImageWriter()
        {
            this.outputDir = ConfigurationManager.AppSettings["outputDir"];
            if (!Directory.Exists(this.outputDir))
            {
                Directory.CreateDirectory(this.outputDir);
            }
        }
        public void WriteImage(string name, Bitmap bmp)
        {
            var path = Path.Combine(this.outputDir, name);

            bmp.Save(path);
        }

    }
}
