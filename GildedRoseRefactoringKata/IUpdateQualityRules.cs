using System;

namespace GildedRoseRefactoringKata
{
    public interface IUpdateQualityServices
    {
        Item Product { get; set; }

        void UpdateProductQuality();
    }
}