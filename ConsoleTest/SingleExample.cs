using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    static class SingleExample
    {
        public static SingleExample ExampleObject { get { return _object; } }
        private static SingleExample _object;
        private SingleExample()
        {
            if(_object == null)
            {
                _object = new SingleExample();
            }
        }
    }
}
