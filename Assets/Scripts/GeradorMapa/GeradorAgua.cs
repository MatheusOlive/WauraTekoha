using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeradorAgua : MonoBehaviour
{
    Dictionary<int, GameObject> TileSet;
    Dictionary<int, GameObject> TileGroups;
    public GameObject Water;
    public List<GameObject> EmptyList = new List<GameObject>();
    public GameObject Empty;
    public int Variedade;

    public int map_width = 16;
    public int map_height = 9;

    List<List<int>> noiseGrid = new List<List<int>>();
    List<List<GameObject>> TileGrid = new List<List<GameObject>>();

    [Range(0.0f, 25.0f)]
    public float magnification = 7.0f;

    public int x_offset;
    public int y_offset;

    void Start()
    {
        x_offset = Random.Range(0, 9999);
        y_offset = Random.Range(0, 9999); 

        CreateTileset();
        CreateTileGroups();
        GenerateMap();
    }

    void CreateTileset()
    {
        TileSet = new Dictionary<int, GameObject>();

        /*for (int i = 0; i < Variedade; i++)
        {
            TileSet.Add(i, EmptyList[i]);
        }*/
        TileSet.Add(0, Water);
        TileSet.Add(1, Empty);
        TileSet.Add(2, Empty);
        TileSet.Add(3, Empty);
        TileSet.Add(4, Empty);


    }
    void CreateTileGroups()
    {
        /** Create empty gameobjects for grouping tiles of the same type, ie
            forest tiles **/

        TileGroups = new Dictionary<int, GameObject>();
        foreach (KeyValuePair<int, GameObject> prefab_pair in TileSet)
        {
            GameObject tile_group = new GameObject(prefab_pair.Value.name);
            tile_group.transform.parent = gameObject.transform;
            tile_group.transform.localPosition = new Vector3(0, 0, 0);
            TileGroups.Add(prefab_pair.Key, tile_group);
        }
    }

    void GenerateMap()
    {
        for (int x = 0; x < map_width; x++)
        {
            noiseGrid.Add(new List<int>());
            TileGrid.Add(new List<GameObject>());

            for (int y = 0; y < map_height; y++)
            {
                int tile_id = GetIdUsingPerlin(x, y);
                noiseGrid[x].Add(tile_id);
                CreateTile(tile_id, x, y);
            }
        }
    }


    int GetIdUsingPerlin(int x, int y)
    {
        float raw_perlin = Mathf.PerlinNoise(
            (x - x_offset) / magnification,
            (y - y_offset) / magnification
        );
        float clamp_perlin = Mathf.Clamp(raw_perlin, 0.0f, 1.0f);
        float scaled_perlin = clamp_perlin * TileSet.Count;
        if (scaled_perlin == Variedade)
        {
            scaled_perlin = Variedade -1;
        }
        return Mathf.FloorToInt(scaled_perlin);
    }


    private void CreateTile(int tile_id, int x, int y)
    {
        GameObject Tile_prefab = TileSet[tile_id];
        GameObject tile_group = TileGroups[tile_id];
        GameObject tile = Instantiate(Tile_prefab, tile_group.transform);

        tile.name = String.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);

        TileGrid[x].Add(tile);
    }
}
