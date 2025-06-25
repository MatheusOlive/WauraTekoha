using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapRenderer : MonoBehaviour
{
    [SerializeField]
    private Tilemap TileMap;
    [SerializeField]
    private TileBase floorTile;



    public void paintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, TileMap, floorTile);
    }
    
    private void PaintTiles(IEnumerable<Vector2Int> Positions, Tilemap tileMap, TileBase Tile)
    {
        foreach (var position in Positions)
        {
            PaintSingleTile(tileMap, Tile, position);
            
        }
    }

    private void PaintSingleTile(Tilemap tileMap, TileBase tile, Vector2Int position)
    {
            var tilePosition = tileMap.WorldToCell((Vector3Int)position);
            tileMap.SetTile(tilePosition, tile);
     
    }

    public void Clear()
    {
        TileMap.ClearAllTiles();
    }
}
