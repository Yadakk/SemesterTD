using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPropertiesContainer : MonoBehaviour
{
    [SerializeField]
    private MapProperties properties;

    public MapProperties Properties => properties;
}
