using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject rts;

    private Camera playerCamera; 
    private Camera rtsCamera;

    public static Camera CurrentCamera { get; private set; }

    private void Awake()
    {
        playerCamera = player.GetComponentInChildren<Camera>();
        rtsCamera = rts.GetComponentInChildren<Camera>();

        CurrentCamera = rtsCamera;
    }

    public void ToggleMode()
    {
        CurrentCamera = CurrentCamera == rtsCamera ? playerCamera : rtsCamera;

        player.SetActive(CurrentCamera == playerCamera);
        rts.SetActive(CurrentCamera == rtsCamera);
    }
}
