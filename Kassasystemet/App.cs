using Kassasystemet.Menu.AdminM;
using Kassasystemet.Menu.StartM;
namespace Kassasystemet
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
