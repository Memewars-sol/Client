using System.Collections.Generic;
using UnityEngine;

public class SquareGrid : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab; // For instantiation of Cell + its visuals.

    // 20x20 int values for the initial map data
    // -1 = wall
    // 0 = grass
    // 1++ = you decide!
    // zero or positive values: cell/tile navigation cost
    // negative values: wall
    private List<int> mapData = new List<int>
    {
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1,
        2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1
    };

    private Vector2Int mapSize = new Vector2Int(30, 30);

    // Neighbour directions for Square Grid with cardinal directions only
    private static readonly List<Vector2Int> NeighbourDirections = new List<Vector2Int>
    {
        new Vector2Int(1,0),    // E
        new Vector2Int(0,-1),   // S
        new Vector2Int(-1,0),   // W
        new Vector2Int(0,1),    // N

        // Add ordinal directions if you want to allow diagonal movement
        // SE, SW, NW, NE
        //new Vector2Int(1,-1),    // SE
        //new Vector2Int(-1,-1),   // SW
        //new Vector2Int(-1,1),   // NW
        //new Vector2Int(1,1)     // NE
    }; private Dictionary<Vector2Int, Tile> cellDictionary;

    // Connection info can be found by querying this collection.
    private Dictionary<Vector2Int, List<Tile>> connectionDictionary;

    // Pass grid coordinate to get Cell object
    // This method may return null if there is no Cell for the given coordinate!
    public Tile GetCell(Vector2Int gridCoordinate)
    {
        cellDictionary.TryGetValue(gridCoordinate, out Tile cell);
        return cell;
    }

    // Pass grid coordinate to get neighbouring Cells in a List
    // This method may return null if there is no List for the given coordinate!
    public List<Tile> GetConnections(Vector2Int gridCoordinate)
    {
        connectionDictionary.TryGetValue(gridCoordinate, out List<Tile> connections);
        return connections;
    }

    public float GetConnectionCost(Tile from, Tile to)
    {
        return GetConnectionCost(from.Coordinate, to.Coordinate);
    }

    public float GetConnectionCost(Tile from, Vector2Int to)
    {
        return GetConnectionCost(from.Coordinate, to);
    }

    public float GetConnectionCost(Vector2Int from, Tile to)
    {
        return GetConnectionCost(from, to.Coordinate);
    }

    public float GetConnectionCost(Vector2Int from, Vector2Int to)
    {
        return Vector2Int.Distance(from, to);
    }


    private Camera cam;
    [SerializeField] private int GuildCount = 3;
    [SerializeField] private Sprite[] GuildSprite = new Sprite[3];
    private GameObject[] Guilds = new GameObject[3];
    [SerializeField] private GameObject logoPrefab;


    private void Update()
    {
        if (cam.orthographicSize < 8)
        {
            for (int i = 0; i < GuildCount; i++)
            {
                Guilds[i].SetActive(false);
            }
            foreach (var kvp in cellDictionary)
            {
                if (kvp.Value.Cost == 0)
                {
                    kvp.Value.gameObject.SetActive(true);
                }
                
            }
        }
        else
        {
            for (int i = 0; i < GuildCount; i++)
            {
                Guilds[i].SetActive(true);
            }
            foreach (var kvp in cellDictionary)
            {
                if (kvp.Value.Cost == 0)
                {
                    kvp.Value.gameObject.SetActive(false);
                }
            }
            for (int j = 0; j < GuildCount; j++)
            {
                Vector3 position = new Vector3();
                int count = 0;
                foreach (var kvp in cellDictionary)
                {
                    if (kvp.Value.Cost == j + 1)
                    {
                        position += kvp.Value.transform.position;
                        count++;
                    }
                }
                Guilds[j].transform.position = position / count;
            }
        }

    }
    private void Start()
    {
        // 1. Generate grid cells
        GenerateGrid();
        // 2. Link the cells
        SolveConnections();
        cam = Camera.main;
        for (int i = 0; i < GuildCount; i++)
        {
            Guilds[i] = Instantiate(logoPrefab);
            Guilds[i].SetActive(false);
            Guilds[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
            Guilds[i].GetComponent<SpriteRenderer>().sprite = GuildSprite[i];
        }
    }

    private void GenerateGrid()
    {
        cellDictionary = new Dictionary<Vector2Int, Tile>();

        // To reduce confusion, as grids are written as ROW,COL while 2D coordinates are written as X,Y.
        // ROW,COL is Y,X
        int rows = mapSize.y, cols = mapSize.x;

        // Iterate rows from last to first so the rendered map looks like how mapData above (line #17) is laid out.
        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = 0; j < cols; j++)
            {
                // initial map data is in 1D array. We use 2D iterators (i & j) so we need to flatten it to 1D to access map data.
                int tileIndex = (i * rows) + j;

                int tileCost = mapData[tileIndex];
                Vector2Int coordinate = new(j, i);

                // Instantiate prefab and set its initial data
                // NOTE: If the cost is negative, then the cell will automatically set itself as not passable.
                Tile cell = Instantiate(tilePrefab, transform);
                cell.Initialize(coordinate, tileCost);

                // Add to cellDictionary
                cellDictionary.Add(coordinate, cell);
            }
        }
    }
    
    public void SolveConnections()
    {
        connectionDictionary = new Dictionary<Vector2Int, List<Tile>>();

        // foreach KVP in cellDictionary
        foreach (KeyValuePair<Vector2Int, Tile> kvp in cellDictionary)
        {
            if (kvp.Value.Cost > 0)
            {
                // coordinate = KVP.Key
                var coord = kvp.Key;

                // Make a list named 'connections' to store Cell
                List<Tile> connections = new();

                // foreach direction in NeighbourDirections
                foreach (Vector2Int direction in NeighbourDirections)
                {
                    // neighbourCoord = coordinate + direction
                    var relativeCoord = coord + direction;

                    // try get neighbourCell in cellDictionary, if found
                    if (cellDictionary.TryGetValue(relativeCoord, out Tile neighbour))
                    {
                        if (GetCell(relativeCoord).Cost != kvp.Value.Cost)
                            continue;
                        // add to connections
                        connections.Add(neighbour);
                    }
                }
                // add entry to connectionDictionary, key: coordinate, value: connections
                connectionDictionary.Add(coord, connections);
            }
        }
    }
    
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        foreach (var kvp in connectionDictionary)
        {
            var list = kvp.Value;

            var cell = GetCell(kvp.Key);

            if (cell == null || !cell.IsPassable) continue;

            foreach (var c in list)
            {
                var start = new Vector3(kvp.Key.x, kvp.Key.y);
                var end = new Vector3(c.Coordinate.x, c.Coordinate.y);

                if (c.IsPassable)
                {
                    Debug.DrawLine(start, end, Color.blue);
                }
            }
        }
    }

#endif
}
