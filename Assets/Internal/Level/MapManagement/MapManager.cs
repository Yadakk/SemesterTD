using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public void SelectMap(MapProperties mapProperties, GameObject towerPrefab, GameObject healthBarPrefab)
    {
        GameObject map = Instantiate(mapProperties.MapPrefab, transform);
        var dataExtractor = map.GetComponentInChildren<MapDataExtractor>();
        var mapData = dataExtractor.ExtractData();

        StartEnemySpawnRoutine(
            mapData.enemySourceTiles,
            mapProperties.EnemyPrefabs, healthBarPrefab,
            mapProperties.EnemySpawnIntervalSeconds
            );

        SetupTowers(towerPrefab, healthBarPrefab, mapData.towerTiles);

        var source = gameObject.AddComponent<AudioSource>();
        source.clip = mapProperties.Music;
        source.Play();
    }

    private void StartEnemySpawnRoutine(
        List<MapTile> enemySourceTiles,
        GameObject[] enemyPrefabs, GameObject healthBarPrefab, float enemySpawnIntervalSeconds)
    {
        StartCoroutine(Routine());

        IEnumerator Routine()
        {
            while (true)
            {
                EnemyFactory.Create(
                    enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
                    healthBarPrefab,
                    enemySourceTiles[Random.Range(0, enemySourceTiles.Count)].transform);

                yield return new WaitForSeconds(enemySpawnIntervalSeconds);
            }
        }
    }

    private void SetupTowers(GameObject towerPrefab, GameObject healthBarPrefab, List<MapTile> towerTiles)
    {
        foreach(var towerTile in towerTiles)
        {
            TowerFactory.Create(towerPrefab, healthBarPrefab, towerTile.transform);
        }
    }
}