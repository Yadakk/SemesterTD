using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileBrushSelectionOutline : MonoBehaviour
{
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    public void Setup()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();

        meshRenderer.sharedMaterial = new Material(Shader.Find("Unlit/SelectShader"));
        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        Deselect();
    }

    public void Select(GameObject go)
    {
        gameObject.SetActive(true);

        if (!go.TryGetComponent<MeshFilter>(out var goMeshFilter)) return;
        if (!go.TryGetComponent<MeshRenderer>(out var goMeshRenderer)) return;

        transform.position = goMeshRenderer.transform.position;
        transform.localScale = goMeshRenderer.transform.lossyScale;
        transform.rotation = goMeshRenderer.transform.rotation;
        meshFilter.sharedMesh = goMeshFilter.sharedMesh;
    }

    public void Deselect()
    {
        gameObject.SetActive(false);
    }
}
