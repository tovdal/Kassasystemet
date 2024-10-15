using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Kassasystemet.Kassasystemet.MenuSystem;


namespace Kassasystemet.Kassasystemet
{
    class Program
    {
        static void Main(string[] args)
        {
            var startRegister = new StartMenu();
            startRegister.RunMenu();
        }
    }
}
