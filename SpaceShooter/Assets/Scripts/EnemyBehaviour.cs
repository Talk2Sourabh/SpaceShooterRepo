using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float _enemySpeed = 2f;

    
    PlayerBehavoiur _playerBehaviour;
    

    private void Start()
    {
        _playerBehaviour = GameObject.FindObjectOfType<PlayerBehavoiur>();
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
            Destroy(this.gameObject);

        }

        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerBehavoiur>().DamagePlayer();
            Destroy(this.gameObject);
        }
    }
}
