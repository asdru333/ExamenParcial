﻿using System.IO;
using System.Web;

namespace PizzaNovita.Handlers
{
    public class ArchivosHandler
    {
        public byte[] ConvertirArchivoABytes(HttpPostedFileBase archivo)
        {
            byte[] bytes;
            BinaryReader lector = new BinaryReader(archivo.InputStream); //
            bytes = lector.ReadBytes(archivo.ContentLength);
            return bytes;
        }
    }
}