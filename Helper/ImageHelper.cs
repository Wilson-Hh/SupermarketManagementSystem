﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SupermarketManagementSystem.Helper
{
    public class ImageHelper
    {

        public static byte[] GetImageString(string fileName)
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 二进制流转换成图片源
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(string _buffer)
        {
            byte[] buffer = Convert.FromBase64String(_buffer);
            MemoryStream memoryStream = new MemoryStream(buffer, 0, buffer.Length);
            memoryStream.Write(buffer, 0, buffer.Length);
            BitmapImage image = new BitmapImage();
            memoryStream.Position = 0;
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = memoryStream;
            image.EndInit();
            image.Freeze();
            return image;
        }
    }

}
