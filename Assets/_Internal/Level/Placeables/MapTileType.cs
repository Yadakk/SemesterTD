using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum MapTileType
{
    None = 0,
    Road = 1,
    Slot = 2,
    EnemySource = 4,
    Tower = 8,
}
