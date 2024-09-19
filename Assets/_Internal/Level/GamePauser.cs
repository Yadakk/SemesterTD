using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauser : MonoBehaviour
{
    public void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
    }
}
