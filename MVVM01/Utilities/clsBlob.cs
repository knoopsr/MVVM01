using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVVM01.Utilities
{
    public class clsBlob
    {
        public static BitmapImage ImageFromBuffer(byte[] buffer)
        {
            MemoryStream stream = new MemoryStream(buffer);
            stream.Seek(0, SeekOrigin.Begin);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.DecodePixelWidth = 300;
            image.EndInit();
            return image;
        }

        public static BitmapImage ImageFromBuffer_GoodQality(byte[] buffer)
        {
            MemoryStream stream = new MemoryStream(buffer);
            stream.Seek(0, SeekOrigin.Begin);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }


        public static void DocumenntExtension(string FullPath)
        {
            string str = FullPath;
            string[] FillPath = str.Split('\\');
            int nr = 0;

            string FileName = FillPath[FillPath.Length - 1];
            string FileExtension =FileName.Substring(FileName.LastIndexOf('.')+1);
            MyExtension = FileExtension;
            MyFileName = FileName;

        }


        private static byte[] _MyDocument;

        public static byte[] MyDocument
        {
            get { return _MyDocument; }
            set { _MyDocument = value; }
        }

        private static string _MyExtension;

        public static string MyExtension
        {
            get { return _MyExtension; }
            set { _MyExtension = value; }
        }

        private static string _MyFileName;

        public static string MyFileName
        {
            get { return _MyFileName; }
            set { _MyFileName = value; }
        }







    }
}
