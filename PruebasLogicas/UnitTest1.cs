using System;
using FacturaElectronica.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace PruebasLogicas
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MetodoDePruebaAutenciacion()
        {
            ModeloTutorial tutorial = new ModeloTutorial();
            tutorial.Autenticacion();
            while (tutorial.EstaResultado)
            {
                Thread.Sleep(1);
              
            }
            Console.WriteLine("Acces token: {0}", tutorial.acessToken);
            Console.WriteLine("Refresh token:{0}", tutorial.refreshToken);
        }
    }
}
