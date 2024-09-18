using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLocation : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    private HealthDisplayer towerHealth;
    private new Renderer renderer;

    public HealthDisplayer TowerHealth => towerHealth;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + new Vector3(0f, 1f, 0f), Vector3.one * 0.4f);
    }

    private void Awake()
    {
        renderer = GetComponent<Renderer>();

        GameObject tower = Instantiate(towerPrefab, transform);
        towerHealth = tower.GetComponent<HealthDisplayer>();
        Renderer towerRenderer = tower.GetComponent<Renderer>();

        tower.transform.position = towerRenderer.bounds.GetPositionOnTop(renderer.bounds);
    }
}
