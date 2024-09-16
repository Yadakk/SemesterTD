using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InteractionRaycaster
{
    public static void Raycast(Ray ray)
    {
        if (!Physics.Raycast(ray, out RaycastHit hitInfo)) return;
        var hitGameObject = hitInfo.collider.gameObject;
        if (!hitGameObject.TryGetComponent<IInteractible>(out var interactible)) return;
        interactible.OnInteract();
    }
}
