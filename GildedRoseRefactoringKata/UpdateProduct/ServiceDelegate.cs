using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public class ServiceDelegate
    {
        private FindUpdateService _findUpdateService = new FindUpdateService();
        private IUpdateQualityServices _updateQualityServices;
        private Type _typeServices;
        private Item _product;

        public void SetItem(Item product)
        {
            this._product = product;
        }

        public void SetServiceType(Type typeServices)
        {
            this._typeServices = typeServices;
        }

        public void DoUpdate()
        {
            _updateQualityServices = _findUpdateService.GedUdateQualityServices(this._typeServices, this._product);
            if (!(this._updateQualityServices is null))
                this._updateQualityServices.UpdateProductQuality();
        }
    }
}
