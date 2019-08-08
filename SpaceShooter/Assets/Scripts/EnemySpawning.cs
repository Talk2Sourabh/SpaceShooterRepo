using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _enemyGenerationRate = 5f;
    [SerializeField]
    private Transform _enemyContainer;
    private bool stopSpawing = false; 
    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy()
    {
        yield return null;
        while(!stopSpawing)
        {
            GameObject temp = Instantiate(_enemyPrefab);
            temp.transform.position = new Vector3(Random.Range(-8, 8), 7.2f, 0);
            temp.transform.SetParent(_enemyContainer);
            yield return new WaitForSeconds(_enemyGenerationRate);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawing = true;
    }
}
