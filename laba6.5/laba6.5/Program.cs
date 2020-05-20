using System;
using System.IO;

namespace laba6._5
{
    class Program
    {
        static void Main(string[] args)
        {
            string PicturePath = @"C:\laba6\Picture.bmp";
            BinaryReader picture = new BinaryReader(new FileStream(PicturePath, FileMode.Open));
            picture.ReadChars(2);
            int size = picture.ReadInt32();
            Console.WriteLine("Size: {0} byte", size);
            picture.ReadInt16();
            picture.ReadInt16();
            picture.ReadInt32();
            picture.ReadInt32();
            int width = picture.ReadInt32();
            Console.WriteLine("Width in pixels: {0} pixels", width);
            int height = picture.ReadInt32();
            Console.WriteLine("Height in pixels: {0} pixels", height);
            picture.ReadInt16();
            short bitPerPixel = picture.ReadInt16();
            Console.Write("Bit/pixel: {0}, ", bitPerPixel);
            if (bitPerPixel == 1)
                Console.WriteLine("monochrome palette, 2 colours");
            if (bitPerPixel == 4)
                Console.WriteLine("4bit palletized, 16 colours");
            if (bitPerPixel == 8)
                Console.WriteLine("8bit palletized, 256 colours");
            if (bitPerPixel == 16)
                Console.WriteLine("16bit RGB, 65536 colours");
            if (bitPerPixel == 24)
                Console.WriteLine("24bit RGB, 16M colours");
            int compressionType = picture.ReadInt32();
            if (compressionType == 0)
                Console.WriteLine("Compression type: without compression");
            if (compressionType == 1)
                Console.WriteLine("Compression type: 8 bit RLE compression");
            if (compressionType == 2)
                Console.WriteLine("Compression type: 4 bit RLE compression");
            picture.ReadInt32();
            int gorizontalResolution = picture.ReadInt32();
            Console.WriteLine("Gorizontal resolution: {0} pixels/m", gorizontalResolution);
            int verticalResolution = picture.ReadInt32();
            Console.WriteLine("Vertical resolution: {0} pixels/m", verticalResolution);
            Console.ReadKey();
        }
    }
}
