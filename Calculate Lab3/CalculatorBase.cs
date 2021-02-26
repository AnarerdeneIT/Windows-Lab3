using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Lab3
{
    public class CalculatorBase
    {
        public  List<Memory> memories = new List<Memory>(10);
        public static Memory memory;
      public void mAdd(int value,int id)
        {
            memories.ElementAt(id).mAdd(value);
        }

        public void mMinus(int value,int id)
        {
            memories.ElementAt(id).mMinus(value);
        }

        public void deleteMemories()
        {
            memories.Clear();
        }

        internal void clearEachMemory(int id)
        {
            Console.WriteLine(id-1);
            memories.ElementAt(id-1).mc();
        }
    }
}
