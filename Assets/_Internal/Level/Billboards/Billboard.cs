using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]
    private float screenVerticalOffset = 5f;

    private Renderer displayerRenderer;

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (displayerRenderer == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = StrategyCamera.Camera.WorldToScreenPoint(
            displayerRenderer.transform.position +
            Vector3.Scale(displayerRenderer.bounds.extents, Vector3.up));

        transform.localPosition += Vector3.up * screenVerticalOffset;
    }

    public void SetDisplayer(Renderer renderer)
    {
        displayerRenderer = renderer;
    }
}
