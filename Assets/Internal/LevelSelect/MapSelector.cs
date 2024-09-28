using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelector : MonoBehaviour
{
    public void SelectMap(MapProperties mapProperties)
    {
        LevelEntryPoint.StaticSetup(mapProperties);
    }
}
