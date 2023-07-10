 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theGameFiles.KeySystem
{

    internal class Lock
    {
        private readonly List<Key.KeyType> neededKey = new();
        private readonly string pngName;
        private readonly string lockName;
        public Lock(List<Key.KeyType> neededKey, string pngName, string lockname) 
        {
            this.neededKey = neededKey;
            this.pngName = pngName;
            this.lockName = lockname;
        }

        public bool KeyFit(Key testKey)
        {
            if(neededKey.Contains(testKey.GetKeyType()){
                //Do things here
                return true;
            }
            else 
            { 
                //Do things here
                return false; 
            }
        }

        public bool TryKey(Key testKey)
        { 
            if(KeyFit(testKey)) 
            { 
                neededKey.Remove(testKey.GetKeyType());
                if (neededKey.Count <= 0)
                {
                    //Do things here
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        






    }
}
