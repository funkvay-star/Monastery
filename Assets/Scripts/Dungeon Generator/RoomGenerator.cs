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

    public Tilemap mainWallTilemap;
    public Tilemap bottomEdgeTilemap;
    public Tilemap topEdgeTilemap;
    public Tilemap leftEdgeTilemap;
    public Tilemap rightEdgeTilemap;

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

        // Generate walls
        for (int x = 0; x < roomWidth; x++)
        {
            TileBase wallTile = mainWallTiles[Random.Range(0, mainWallTiles.Length)];
            mainWallTilemap.SetTile(new Vector3Int(x, roomHeight - 1, 0), wallTile); // Top wall
            mainWallTilemap.SetTile(new Vector3Int(x, 0, 0), wallTile); // Bottom wall
        }

        for (int y = 0; y < roomHeight; y++)
        {
            TileBase wallTile = mainWallTiles[Random.Range(0, mainWallTiles.Length)];
            mainWallTilemap.SetTile(new Vector3Int(0, y, 0), wallTile); // Left wall
            mainWallTilemap.SetTile(new Vector3Int(roomWidth - 1, y, 0), wallTile); // Right wall
        }

        // Generate edges adjacent to walls, adjusted for new positions
        for (int x = 0; x < roomWidth; x++)
        {
            TileBase topEdgeTile = topEdgeTiles[Random.Range(0, topEdgeTiles.Length)];
            TileBase bottomEdgeTile = bottomEdgeTiles[Random.Range(0, bottomEdgeTiles.Length)];
            topEdgeTilemap.SetTile(new Vector3Int(x, roomHeight - 2, 0), topEdgeTile); // Below top wall
            bottomEdgeTilemap.SetTile(new Vector3Int(x, 1, 0), bottomEdgeTile); // Above bottom wall
        }

        for (int y = 0; y < roomHeight; y++)
        {
            TileBase leftEdgeTile = leftEdgeTiles[Random.Range(0, leftEdgeTiles.Length)];
            TileBase rightEdgeTile = rightEdgeTiles[Random.Range(0, rightEdgeTiles.Length)];
            leftEdgeTilemap.SetTile(new Vector3Int(1, y, 0), leftEdgeTile); // Right of left wall
            rightEdgeTilemap.SetTile(new Vector3Int(roomWidth - 2, y, 0), rightEdgeTile); // Left of right wall
        }
    }

}
