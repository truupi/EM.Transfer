using System;
using EM.Transfer.FileConversion.Managers;
using EM.Transfer.FileConversion.Unity;
using Microsoft.Practices.Unity;

namespace EM.Transfer.FileConversion
{
    internal class Program
    {
        private static void Main()
        {
            using (var container = new UnityContainer())
            {
                Bootstrapper.SetupContainer(container);

                var manager = container.Resolve<ITransactionManager>();

                manager.Start();
            }

            Console.ReadKey();
        }
    }
}
