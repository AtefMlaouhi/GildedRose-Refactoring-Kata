using System;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace GildedRoseRefactoringKata
{
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            var pathApp = AppDomain.CurrentDomain.BaseDirectory;
            var lines = File.ReadAllLines($"{pathApp}//ThirtyDays.txt");

            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));
            Program.Main(new string[] { });

            String output = fakeoutput.ToString();

            var outputLines = output.Split('\n');
            for(var i = 0; i<Math.Min(lines.Length, outputLines.Length); i++) 
            {
                var y = lines[i];
                Assert.AreEqual(lines[i], outputLines[i].Split('\r')[0]);
            }
        }
    }
}
