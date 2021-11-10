using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRWebPack.Facades;

namespace SignalRWebPack.Network
{
    public class TestingManager
    {
        public void Testing(){
            Facade tests = new Facade();
            tests.CreateTestUnits();
            tests.TestStrategy();
            tests.TestPrototype();
            Console.WriteLine("----------------------");
        }      
    }
}