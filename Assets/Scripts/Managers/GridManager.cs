using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    //making this a singleton 
    public static GridManager Instance;
    [SerializeField] private int width, height;
    [SerializeField] private Tile _grassTile, _mountianTile;
    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    [Header("Debug")]
    [Range(0f, 1f)]
    [SerializeField] float tileProbability = 0.2f;
    private void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var randomTile = Random.Range(0f, 1f) < tileProbability ? _mountianTile : _grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";


                spawnedTile.Init(x, y);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        
        GameManager.Instance.ChangeState(GameState.SpawnPlayer);

    }

    public Tile GetPlayerSpawn()
    {
        return _tiles.Where(t=>t.Key.y < height/2 && t.Value.walkable).OrderBy(t=>Random.value).First().Value;
    }

    public Tile GetEnemySpawn()
    {
        return _tiles.Where(t => t.Key.y > height / 2 && t.Value.walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetTileAPos(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        else
        {
            return null; 
        }
    }

}
