using System.Collections.Generic;
using _Project.Scripts.Configs.Inventory;
using _Project.Scripts.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Utils.Factory
{
    public class GridFactory : IGridFactory
    {
        private readonly DiContainer _container;
        private readonly GridLayoutGroup _gridPrefab;
        private readonly GridConfig _gridConfig;
        private readonly Canvas _canvas;
        private readonly CellView _cellPrefab;

        public GridFactory(DiContainer container, GridLayoutGroup gridPrefab, GridConfig gridConfig,
            Canvas canvas,
            CellView cellPrefab)
        {
            _container = container;
            _gridPrefab = gridPrefab;
            _gridConfig = gridConfig;
            _canvas = canvas;
            _cellPrefab = cellPrefab;
        }

        public List<CellView> CreateGridWithCells()
        {
            var grid = _container.InstantiatePrefabForComponent<GridLayoutGroup>(_gridPrefab, _canvas.transform);

            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = _gridConfig.Size.x;

            List<CellView> cells = new();
            for (var i = 0; i < _gridConfig.Size.x * _gridConfig.Size.y; i++)
            {
                var cell = _container.InstantiatePrefabForComponent<CellView>(_cellPrefab, grid.transform);
                cells.Add(cell);
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(grid.GetComponent<RectTransform>());
            grid.enabled = false;
            
            return cells;
        }
    }
}