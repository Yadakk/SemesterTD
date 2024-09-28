using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class PointerOnUI
{
    public static bool Check()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
