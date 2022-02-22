using System;
using System.Security.Cryptography;
using System.Text;
using mvImoveis.Models;
using System.Linq;
using System.Collections.Generic;

namespace mvImoveis.Models
{
    public static class Criptografo
    {
        public static string TextoCriptografado (string textoClaro)
        {
            MD5 MD5Hasher = MD5.Create();

            byte[] by = Encoding.Default.GetBytes(textoClaro);
            byte[] bytesCriptografado = MD5Hasher.ComputeHash(by);

            StringBuilder SB = new StringBuilder();

            foreach (byte b in bytesCriptografado)
            {
                string DebugB = b.ToString("x2");
                SB.Append(DebugB);
            }

            return SB.ToString();
        }
    }
}