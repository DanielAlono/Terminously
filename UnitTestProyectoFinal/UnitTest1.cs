using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TestStack.White;

namespace UnitTestProyectoFinal
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Application app = Application.Launch("Proyecto Final.exe");
        }
    }
}
