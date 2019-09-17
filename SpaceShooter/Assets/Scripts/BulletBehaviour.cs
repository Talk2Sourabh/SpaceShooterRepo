using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    float _bulletSpeed = 20f;

    bool _isEnemyBullet;

    // Update is called once per frame
    void Update()
    {
        if (!_isEnemyBullet)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        
        transform.Translate(Vector3.up * Time.deltaTime * _bulletSpeed);

        if (transform.position.y >= 7f)
        {

            if (this.transform.parent != null)
            {
                Destroy(this.transform.parent.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    void MoveDown()
    {

        transform.Translate(Vector3.down * Time.deltaTime * _bulletSpeed);

        if (transform.position.y <= -7f)
        {

            if (this.transform.parent != null)
            {
                Destroy(this.transform.parent.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void AssiagnBulletAsEnemyBullet()
    {
        _isEnemyBullet = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _isEnemyBullet)
        {
            Debug.Log(transform.GetSiblingIndex());
            other.GetComponent<PlayerBehavoiur>().DamagePlayer();
            Destroy(this.gameObject);
        }
    }
}
