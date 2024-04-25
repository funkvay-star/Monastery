using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGenerator : MonoBehaviour
{
    public TileBase[] mainWallTiles;
    public TileBase[] bottomEdgeTiles;
    public TileBase[] topEdgeTiles;
    public TileBase[] leftEdgeTiles;
    public TileBase[] rightEdgeTiles;

    public Tilemap tilemap;

    public int minWidth = 5;
    public int maxWidth = 15;
    public int minHeight = 5;
    public int maxHeight = 15;

    private int roomWidth;
    private int roomHeight;

    void Start()
    {
        GenerateRoom();
    }

    void GenerateRoom()
    {
        roomWidth = Random.Range(minWidth, maxWidth + 1);
        roomHeight = Random.Range(minHeight, maxHeight + 1);

        // Generate top and bottom walls
        for (int x = 0; x < roomWidth; x++)
        {
            TileBase topWallTile = mainWallTiles[Random.Range(0, mainWallTiles.Length)];
            TileBase bottomWallTile = mainWallTiles[Random.Range(0, mainWallTiles.Length)];
            tilemap.SetTile(new Vector3Int(x, roomHeight - 1, 0), topWallTile);
            tilemap.SetTile(new Vector3Int(x, 0, 0), bottomWallTile);

            // Draw green boxes around top and bottom walls
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(x, roomHeight - 1, 0)), tilemap.CellToWorld(new Vector3Int(x + 1, roomHeight - 1, 0)), Color.green, 100f);
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(x, 0, 0)), tilemap.CellToWorld(new Vector3Int(x + 1, 0, 0)), Color.green, 100f);
        }

        // Generate left and right walls
        for (int y = 1; y < roomHeight - 1; y++)
        {
            TileBase leftWallTile = mainWallTiles[Random.Range(0, mainWallTiles.Length)];
            TileBase rightWallTile = mainWallTiles[Random.Range(0, mainWallTiles.Length)];
            tilemap.SetTile(new Vector3Int(0, y, 0), leftWallTile);
            tilemap.SetTile(new Vector3Int(roomWidth - 1, y, 0), rightWallTile);

            // Draw red boxes around left and right walls
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(0, y, 0)), tilemap.CellToWorld(new Vector3Int(0, y + 1, 0)), Color.red, 100f);
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(roomWidth - 1, y, 0)), tilemap.CellToWorld(new Vector3Int(roomWidth - 1, y + 1, 0)), Color.red, 100f);
        }

        // Place bottom edges
        for (int x = 0; x < roomWidth; x++)
        {
            TileBase bottomEdgeTile = bottomEdgeTiles[Random.Range(0, bottomEdgeTiles.Length)];
            tilemap.SetTile(new Vector3Int(x, 1, 0), bottomEdgeTile);

            // Draw blue boxes around bottom edges
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(x, 1, 0)), tilemap.CellToWorld(new Vector3Int(x + 1, 1, 0)), Color.blue, 100f);
        }

        // Place top edges
        for (int x = 0; x < roomWidth; x++)
        {
            TileBase topEdgeTile = topEdgeTiles[Random.Range(0, topEdgeTiles.Length)];
            tilemap.SetTile(new Vector3Int(x, roomHeight - 2, 0), topEdgeTile);

            // Draw yellow boxes around top edges
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(x, roomHeight - 2, 0)), tilemap.CellToWorld(new Vector3Int(x + 1, roomHeight - 2, 0)), Color.yellow, 100f);
        }

        // Place left edges
        for (int y = 1; y < roomHeight - 1; y++)
        {
            TileBase leftEdgeTile = leftEdgeTiles[Random.Range(0, leftEdgeTiles.Length)];
            tilemap.SetTile(new Vector3Int(1, y, 0), leftEdgeTile);

            // Draw blue boxes around left edges
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(1, y, 0)), tilemap.CellToWorld(new Vector3Int(1, y + 1, 0)), Color.blue, 100f);
        }

        // Place right edges
        for (int y = 1; y < roomHeight - 1; y++)
        {
            TileBase rightEdgeTile = rightEdgeTiles[Random.Range(0, rightEdgeTiles.Length)];
            tilemap.SetTile(new Vector3Int(roomWidth - 2, y, 0), rightEdgeTile);

            // Draw yellow boxes around right edges
            Debug.DrawLine(tilemap.CellToWorld(new Vector3Int(roomWidth - 2, y, 0)), tilemap.CellToWorld(new Vector3Int(roomWidth - 2, y + 1, 0)), Color.yellow, 100f);
        }
    }
}