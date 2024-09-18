using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public void SelectMap(GameObject prefab)
    {
        Instantiate(prefab, transform, true);
    }
}
