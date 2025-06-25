using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
 
public class GeradorDeMapa : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    [SerializeField]
    private int iteration = 10;
    [SerializeField]
    private int walkLenght = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    [SerializeField]
    private TileMapRenderer tileMapRenderer;

    public GameObject Player;
    public void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        //tileMapRenderer.Clear();
        tileMapRenderer.paintFloorTiles(floorPositions);
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iteration; i++)
        {
            var path = MapaProcedural.SimpleRandomWalk(currentPosition, walkLenght);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));

            }
        }
            return floorPositions;
    }

    void Update()
    {
        startPosition = new Vector2Int((int)Player.transform.position.x, (int)Player.transform.position.y);
        RunProceduralGeneration();
        if (Input.GetKeyDown("w"))
        {
            RunProceduralGeneration();
        }   
    }
}
