using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatrolController : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private int patrolPointDistance = 3;
    [SerializeField] private int patrolPointsCount = 3;
    [Space, SerializeField] private float spawnDelay = 1;
    private Enemy _spawnedEnemy;

    private void OnEnable()
    {
        EventManager.GameStarted += SpawnNewEnemy;
    }
    
    private void OnDisable()
    {
        EventManager.GameStarted -= SpawnNewEnemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, patrolPointDistance);
    }

    public Vector3 GetRandomPatrolPoint()
    {
        float randAngle = Random.Range(0, 360) * Mathf.Deg2Rad;

        Vector3 point = new Vector3(Mathf.Cos(randAngle), 0, Mathf.Sin(randAngle)) * patrolPointDistance +
                        transform.position;

        return point;
    }

    public void SpawnNewEnemyWithDelay()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }
    
    public void SpawnNewEnemy()
    {
        Enemy enemyObj = Instantiate(enemyPrefab.gameObject, transform.position, Quaternion.identity, transform)
            .GetComponent<Enemy>();

        _spawnedEnemy = enemyObj;
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnNewEnemy();
    }
}
