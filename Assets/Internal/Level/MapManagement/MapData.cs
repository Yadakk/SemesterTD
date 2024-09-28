using System.Collections;
using System.Collections.Generic;

public class MapData
{
    public MapData(MapTile[] mapTiles)
    {
        foreach (MapTile mapTile in mapTiles)
        {
            if (mapTile.Type.HasFlag(MapTileType.EnemySource))
            {
                enemySourceTiles.Add(mapTile);
            }
            else if (mapTile.Type.HasFlag(MapTileType.Tower))
            {
                towerTiles.Add(mapTile);
            }
        }
    }

    public List<MapTile> enemySourceTiles = new();
    public List<MapTile> towerTiles = new();
}
