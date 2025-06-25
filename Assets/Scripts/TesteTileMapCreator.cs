using UnityEngine;
using UnityEngine.Tilemaps;


public class TesteTileMapCreator : MonoBehaviour
{
    [SerializeField]
    private Tilemap TileMap;
    [SerializeField]
    private TileBase Ground;

   

    public int ValorInicialRandomicoDePosicaoChao;
    public int LarguraMaxima;
    public int AlturaMaxima;
    public Vector2Int PosicaoChao;

    [Header("Geração De Rios")]
    [SerializeField]
    private TileBase Water;
    public Vector2Int EscalaDeTamanhoDosRios;
    public Vector2Int EscalaDeQuantidadeDosRios;    
    
    [Header("Geração De Grama")]
    [SerializeField]
    private TileBase Grass;
    public Vector2Int EscalaDeTamanhoDasIlhas;
    public Vector2Int EscalaDeQuantidadeDasIlhas;

    void Start()
    {
        ValorInicialRandomicoDePosicaoChao = Random.Range(EscalaDeQuantidadeDosRios.x, EscalaDeQuantidadeDosRios.y);
        //Gerador De Terra. preenche todo o campo Com Terra apartir do tamanho definido de mapa
        for (int x = 0; x < AlturaMaxima; x++)
        {
            for (int i = 0; i < LarguraMaxima; i++)
            {
                PaintSingleTile(TileMap, Ground, PosicaoChao);
                PosicaoChao.x = i;
            }
            PosicaoChao.y = x;
        }
        //Gerador De Rios.

        for (int x = 0; x < ValorInicialRandomicoDePosicaoChao; x++)
        {
            PosicaoChao.x = Random.Range(0, LarguraMaxima);
            PosicaoChao.y = Random.Range(0, AlturaMaxima);
            PaintRiverTile(TileMap, Water, PosicaoChao);
        }
        //Gerador De Grama.
        for (int x = 0; x < ValorInicialRandomicoDePosicaoChao; x++)
        {
            PosicaoChao.x = Random.Range(0, LarguraMaxima);
            PosicaoChao.y = Random.Range(0, AlturaMaxima);
            PaintIsleTile(TileMap, Grass, PosicaoChao);
        }
        
    }
    private void PaintRiverTile(Tilemap tileMap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tileMap.WorldToCell((Vector3Int)position);
        tileMap.SetTile(tilePosition, tile);

        var TamanhoInlhas = Random.Range(EscalaDeTamanhoDosRios.x, EscalaDeTamanhoDosRios.y);
        Vector2Int previousPosition = position;
        Vector2Int newPosition = position;

        for (int i = 0; i < TamanhoInlhas; i++)
        {

            float RandomDirection = Random.Range(0, 100);


            if (RandomDirection <= 12.5f)
            {
                newPosition.x -= 1;
                Debug.LogWarning(1);
            }
            if (RandomDirection <= 25 && RandomDirection >= 12.5f)
            {
                newPosition.x -= 1;
                newPosition.y += 1;
                Debug.LogWarning(2);
            }
            if (RandomDirection <= 37.5f && RandomDirection >= 25)
            {
                newPosition.y += 1;
                Debug.LogWarning(3);
            }
            if (RandomDirection <= 50 && RandomDirection >= 37.5f)
            {
                newPosition.x += 1;
                newPosition.y += 1;
                Debug.LogWarning(4);
            }
            if (RandomDirection <= 62.5f && RandomDirection >= 50)
            {
                newPosition.x += 1;
                Debug.LogWarning(5);
            }
            if (RandomDirection <= 75 && RandomDirection >= 62.5f)
            {
                newPosition.x += 1;
                newPosition.y -= 1;
                Debug.LogWarning(6);
            }
            if (RandomDirection <= 87.5f && RandomDirection >= 75)
            {
                newPosition.y -= 1;
                Debug.LogWarning(7);
            }
            if (RandomDirection <= 100 && RandomDirection >= 87.5f)
            {
                newPosition.x -= 1;
                newPosition.y -= 1;
                Debug.LogWarning(8);
            }

            /*Debug.LogWarning(newPosition);
            Debug.LogWarning(RandomDirection);*/
            var NewtilePosition = tileMap.WorldToCell((Vector3Int)newPosition);
            tileMap.SetTile(NewtilePosition, tile);

        }
    }

    private void PaintIsleTile(Tilemap tileMap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tileMap.WorldToCell((Vector3Int)position);
        tileMap.SetTile(tilePosition, tile);

        var TamanhoInlhas = Random.Range(EscalaDeTamanhoDasIlhas.x, EscalaDeTamanhoDasIlhas.y);
        Vector2Int previousPosition = position;
        Vector2Int newPosition = position;

        for (int i = 0; i < TamanhoInlhas; i++)
        {

            float RandomDirection = Random.Range(0, 100);


            if (RandomDirection <= 12.5f)
            {
                newPosition.x -= 1;
                Debug.LogWarning(1);
            }
            if (RandomDirection <= 25 && RandomDirection >= 12.5f)
            {
                newPosition.x -= 1;
                newPosition.y += 1;
                Debug.LogWarning(2);
            }
            if (RandomDirection <= 37.5f && RandomDirection >= 25)
            {
                newPosition.y += 1;
                Debug.LogWarning(3);
            }
            if (RandomDirection <= 50 && RandomDirection >= 37.5f)
            {
                newPosition.x += 1;
                newPosition.y += 1;
                Debug.LogWarning(4);
            }
            if (RandomDirection <= 62.5f && RandomDirection >= 50)
            {
                newPosition.x += 1;
                Debug.LogWarning(5);
            }
            if (RandomDirection <= 75 && RandomDirection >= 62.5f)
            {
                newPosition.x += 1;
                newPosition.y -= 1;
                Debug.LogWarning(6);
            }
            if (RandomDirection <= 87.5f && RandomDirection >= 75)
            {
                newPosition.y -= 1;
                Debug.LogWarning(7);
            }
            if (RandomDirection <= 100 && RandomDirection >= 87.5f)
            {
                newPosition.x -= 1;
                newPosition.y -= 1;
                Debug.LogWarning(8);
            }

            /*Debug.LogWarning(newPosition);
            Debug.LogWarning(RandomDirection);*/
            var NewtilePosition = tileMap.WorldToCell((Vector3Int)newPosition);
            tileMap.SetTile(NewtilePosition, tile);

        }

    }
    

    private void PaintSingleTile(Tilemap tileMap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tileMap.WorldToCell((Vector3Int)position);
        tileMap.SetTile(tilePosition, tile);

    }

    // Update is called once per frame
}
