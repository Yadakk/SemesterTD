using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]
    private float screenVerticalOffset = 5f;

    private Transform displayer;

    private void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        if (displayer == null)
        {
            Destroy(gameObject);
            return;
        }

        Bounds bounds = displayer.gameObject.CalculateBounds();
        Vector3 positionOnTop = new(displayer.position.x, bounds.GetPositionOnTop().y, displayer.position.z);

        transform.position = StrategyCamera.Camera.WorldToScreenPoint(positionOnTop);
        transform.localPosition += Vector3.up * screenVerticalOffset;
    }

    public void SetDisplayer(Transform displayer)
    {
        this.displayer = displayer;
    }
}
