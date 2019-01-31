using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public class FindUpdateService
    {
        public IUpdateQualityServices GedUdateQualityServices(Type updateQualityServices, Item product)
        {
            return (IUpdateQualityServices)Activator.CreateInstance(updateQualityServices, new object[] { product });
        }
    }
}
