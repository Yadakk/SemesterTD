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

    private Slider healthSlider;

    private float health;

    public float Health
    {
        get => health;
        set
        {
            if (value <= 0)
            {
                Destroy(gameObject);
                return;
            }

            healthSlider.value = value / maxHealth;

            health = value;
        }
    }

    private void Start()
    {
        var billboard = BillboardLayer.Instance.CreateBillboard(healthBillboardPrefab, transform);
        healthSlider = billboard.GetComponentInChildren<Slider>();

        Health = maxHealth;
    }
}
