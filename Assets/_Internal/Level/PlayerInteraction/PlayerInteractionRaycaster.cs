using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInteractionRaycaster
{
    public static void Raycast(float maxDistance)
    {
        if (!Physics.Raycast(Camera.main.ScreenPointToRay(Camera.main.transform.position), out RaycastHit hitInfo, maxDistance)) return;
        var hitGameObject = hitInfo.collider.gameObject;
        if (!hitGameObject.TryGetComponent<IInteractible>(out var interactible)) return;
        interactible.Interact();
    }
}
