using System.Collections.Generic;
using _Project.Scripts.Inventory;

namespace _Project.Scripts.Utils.Factory
{
    public interface IGridFactory
    {
        public List<CellView> CreateGridWithCells();
    }
}