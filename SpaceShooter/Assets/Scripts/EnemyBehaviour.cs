using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float _enemySpeed = 2f;

    
    PlayerBehavoiur _playerBehaviour;
    [SerializeField]
    private GameObject _explosionPrefab;
    private Collider2D _collider2D;

    private void Start()
    {
        _playerBehaviour = GameObject.FindObjectOfType<PlayerBehavoiur>();
        _collider2D = GetComponent<Collider2D>();
    }
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _enemySpeed);
        if (transform.position.y < -5.64f)
        {
            transform.position = new Vector3(Random.Range(-8, 8), 7.2f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (other.transform.parent != null )
            {
                Destroy(other.transform.parent.gameObject);
            }
            else
            {
                Destroy(other.gameObject);
            }

            _playerBehaviour.UpdateScore(10);
            GenerateExplosionEffect();
            Destroy(this.gameObject,1.2f);

        }

        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehavoiur>().DamagePlayer();
            GenerateExplosionEffect();
            Destroy(this.gameObject, 1.2f);
        }
    }

    void GenerateExplosionEffect()
    {
        GameObject temp = Instantiate(_explosionPrefab);
        temp.transform.position = this.transform.position;
        temp.transform.SetParent(this.transform);

        RemoveEnemyComponent();
    }

    void RemoveEnemyComponent()
    {
        _enemySpeed = 0f;
        _collider2D.enabled = false;
    }
}

