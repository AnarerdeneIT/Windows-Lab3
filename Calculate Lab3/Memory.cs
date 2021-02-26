using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Lab3
{
    public class Memory
    {
        private int utga = 0;


        public int GetSetValue
        {
            get
            {
                return utga;
            }
            set
            {
                utga = value;
            }
        }

        public void mc()
        {
            utga = 0;
        }

        public void mAdd(int value)
        {
            utga += value;
        }
        public void mMinus(int value)
        {
            utga -= value;
        }
    }
    }
