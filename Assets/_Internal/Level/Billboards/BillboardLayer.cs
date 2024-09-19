using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardLayer : MonoBehaviour
{
    public static BillboardLayer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Billboard CreateBillboard(GameObject billboardPrefab, Transform source)
    {
        var billboardGO = Instantiate(billboardPrefab, transform);
        var billboard = billboardGO.GetComponent<Billboard>();
        billboard.SetDisplayer(source);
        return billboard;
    }
}
