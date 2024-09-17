using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBillboardPrefab;

    [SerializeField]
    private float maxHealth = 100f;

    private Renderer _renderer;

    private Slider healthSlider;

    private float health;

    public float Health
    {
        get => health;
        set
        {
            healthSlider.value = value / maxHealth;
            health = value;
        }
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        var billboard = BillboardLayer.Instance.CreateBillboard(healthBillboardPrefab, _renderer);
        healthSlider = billboard.GetComponentInChildren<Slider>();

        Health = maxHealth;
    }
}
