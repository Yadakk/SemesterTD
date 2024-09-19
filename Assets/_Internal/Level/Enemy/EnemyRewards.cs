using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRewards : MonoBehaviour
{
    [SerializeField]
    private int unitReward = 50;

    private void OnDestroy()
    {
        NutsAndBolts.Instance.Amount += unitReward;
        Destroy(gameObject);
    }
}
