using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBillboardPrefab;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        BillboardLayer.Instance.CreateBillboard(healthBillboardPrefab, _renderer);
    }
}
