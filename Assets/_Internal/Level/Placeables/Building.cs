using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building", order = 51)]
public class Building : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int cost;

    [SerializeField]
    private MapTileType canPlaceOn;

    public GameObject Prefab => prefab;

    public int Cost => cost;

    public MapTileType CanPlaceOn => canPlaceOn;

    public bool TryBuy()
    {
        if (cost > NutsAndBolts.Instance.Amount) return false;
        NutsAndBolts.Instance.Amount -= cost;
        return true;
    }
}
