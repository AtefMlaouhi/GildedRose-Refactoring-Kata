using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseRefactoringKata
{
    public class UpdateQualityClient
    {
        ServiceDelegate _updateService;


        public void SetUpdateQualityClient(ServiceDelegate updateService)
        {
            this._updateService = updateService;
        }

        public void DoUpdate()
        {
            this._updateService.DoUpdate();
        }
    }
}
