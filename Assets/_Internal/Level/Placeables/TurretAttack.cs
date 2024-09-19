using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField]
    private float attackIntervalSeconds = 1f;

    [SerializeField]
    private float damage = 20f;

    private readonly List<MonoHealth> enemiesInRange = new();

    private bool readyToShoot = true;

    public MonoHealth TargetedEnemy
    {
        get
        {
            while (enemiesInRange[0] == null)
            {
                enemiesInRange.RemoveAt(0);
            }

            if (enemiesInRange.Count == 0) return null;
            return enemiesInRange[0];
        }
    }

    private void Update()
    {
        if (enemiesInRange.Count == 0) return;

        RotateTowardEnemy();
        if (readyToShoot) ShootAtEnemy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<EnemyMovement>(out var enemyMovement)) return;
        RegisterEnemy(enemyMovement.GetComponent<MonoHealth>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.TryGetComponent<EnemyMovement>(out var enemyMovement)) return;
        UnregisterEnemy(enemyMovement.GetComponent<MonoHealth>());
    }

    private void RegisterEnemy(MonoHealth enemy)
    {
        if (enemiesInRange.Contains(enemy)) return;
        enemiesInRange.Add(enemy);
    }

    private void UnregisterEnemy(MonoHealth enemy)
    {
        if (!enemiesInRange.Contains(enemy)) return;
        enemiesInRange.Remove(enemy);
    }

    private void ShootAtEnemy()
    {
        readyToShoot = false;
        TargetedEnemy.Health -= damage;

        StartCoroutine(Routine());

        IEnumerator Routine()
        {
            yield return new WaitForSeconds(attackIntervalSeconds);
            readyToShoot = true;
        }
    }

    private void RotateTowardEnemy()
    {
        Quaternion targetRot = Quaternion.LookRotation(TargetedEnemy.transform.position - transform.position, Vector3.up);
        targetRot = Quaternion.Euler(0f, targetRot.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 3f);
    }
}