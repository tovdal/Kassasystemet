using Kassasystemet.Kassasystemet.MenuSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystemet.Kassasystemet
{
    internal class App
    {
        public void Run()
        {
            var run = new StartMenu();
            run.RunMenu();
        }

    }
}
