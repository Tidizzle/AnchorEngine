using System;
using System.Collections.Generic;
using Engine;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var t = new AncApplication(1680, 1050, false, false))
            {
                t.Start(new scene1("Scene1"));
            }
        }
    }
}