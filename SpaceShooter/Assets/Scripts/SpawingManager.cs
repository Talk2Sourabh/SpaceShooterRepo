using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _enemyGenerationRate = 5f;
    [SerializeField]
    private Transform _enemyContainer;
    private bool stopSpawing = false;

    [SerializeField]
    List<GameObject> _powerObjects;

    [SerializeField]
    float powerGenerationTime = 10f;

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
        StartCoroutine(GeneratePowerObject());
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

    IEnumerator GeneratePowerObject()
    {
        yield return null;
        while (!stopSpawing)
        {
            GameObject temp = Instantiate(_powerObjects[Random.Range(0, _powerObjects.Count)]);
            temp.transform.position = new Vector3(Random.Range(-8, 8), 7.2f, 0);
            yield return new WaitForSeconds(powerGenerationTime);
        }
    }


    public void OnPlayerDeath()
    {
        stopSpawing = true;
    }
}
