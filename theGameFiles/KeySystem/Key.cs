using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace theGameFiles.KeySystem
{
    internal class Key
    {
        public enum KeyType //Can name these whatever
        {
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }

        private readonly KeyType type;
        private readonly string png_name;
        public Key(KeyType type, string png_name)
        {
            this.type = type;
            this.png_name = png_name;
        }
        public KeyType GetKeyType()
            { return type; }
        public string GetPngName() 
            { return png_name;}
    }
}
