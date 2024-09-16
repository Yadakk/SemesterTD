using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class SelectableTile : MonoBehaviour, IInteractible
{
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void OnInteract()
    {
        Vector3 bounds = render.bounds.extents;
        SelectionOutline.Instance.Select(
            pos: transform.position + new Vector3(0f, bounds.y + 0.01f, 0f), 
            size: new Vector2(bounds.x * 2, bounds.z * 2));
    }
}
