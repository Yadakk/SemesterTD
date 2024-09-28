using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building Levels", menuName = "Building Levels", order = 51)]
public class BuildingLevels : ScriptableObject
{
    [SerializeField]
    private Building[] levels;

    public Building[] Levels => levels;
}
