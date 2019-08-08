using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavoiur : MonoBehaviour
{
    [SerializeField]
    private float _playerMovementSpeed = 5f;

    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _fireRate = 0.1f;

    void Start()
    {
         
    }
    
    void Update()
    {
        CalclulateMovement();
        ShootBullet();    
    }

    void CalclulateMovement()
    {

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        Vector3 _direction = new Vector3(_horizontal, _vertical, 0f);
        transform.Translate(_direction * Time.deltaTime * _playerMovementSpeed);

        float _xValue = transform.position.x;
        if (_xValue >= 9)
        {
            transform.position = new Vector3(-9f, transform.position.y, 0f);
        }
        else if (_xValue <= -9)
        {
            transform.position = new Vector3(9f, transform.position.y, 0f);
        }

        float _yValue = Mathf.Clamp(transform.position.y, -3.8f, 0f);
        transform.position = new Vector3(transform.position.x, _yValue, 0f);
    }

    float _timeGapBtwBullets = 0f;
    void ShootBullet()
    {
        _timeGapBtwBullets += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && _timeGapBtwBullets >= _fireRate)
        {
            _timeGapBtwBullets = 0f;
            GameObject _bullet = Instantiate(_bulletPrefab,transform.position,Quaternion.identity);
        }
    }
    [SerializeField]
    private int _playerLifes = 3;
    [SerializeField]
    private EnemySpawning _enemySpawning;
    public void DamagePlayer()
    {
        _playerLifes--;
        if (_playerLifes == 0)
        {
            _enemySpawning.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}

