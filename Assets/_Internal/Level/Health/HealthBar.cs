using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MonoHealth))]
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private GameObject healthSliderPrefab;

    private MonoHealth monoHealth;

    private Slider healthSlider;

    private void Awake()
    {
        monoHealth = GetComponent<MonoHealth>();
    }

    private void Start()
    {
        var billboard = BillboardLayer.Instance.CreateBillboard(healthSliderPrefab, transform);
        healthSlider = billboard.GetComponentInChildren<Slider>();

        monoHealth.OnValueChanged += UpdateHealthBar;
        UpdateHealthBar(monoHealth.Health);
    }

    private void UpdateHealthBar(float newValue)
    {
        healthSlider.value = newValue / monoHealth.MaxHealth;
    }
}
