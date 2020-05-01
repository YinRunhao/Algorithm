using System;
using System.Diagnostics;
using System.Text;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            IAlgorithm test = new Calculator();
            test.Execute();
        }
    }
}
