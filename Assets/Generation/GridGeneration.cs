using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridGeneration : MonoBehaviour
{
    [SerializeField] private Grid _grid;
    [SerializeField] private GameObject _tilePrefab;
    private int _gridHeight = 10;
    private int _gridWidht = 10;
    // Start is called before the first frame update
    private void Start()
    {
        Generate();
    }
    private void Generate()
    {
        for (int x = 0 ; x < _gridHeight ; x ++)
        {
            for (int y = 0 ; y < _gridWidht ; y ++ )
            {
                var _worldPosition = _grid.GetCellCenterWorld(new Vector3Int(x , y ));
                Instantiate(_tilePrefab , _worldPosition , Quaternion.identity);
            }
        }
    }
}
