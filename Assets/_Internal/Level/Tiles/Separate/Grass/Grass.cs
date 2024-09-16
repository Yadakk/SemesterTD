using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Debug.Log("Grass");
    }
}
