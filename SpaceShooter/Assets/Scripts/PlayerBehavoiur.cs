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
    private GameObject _tripleBulletPrefab;
    [SerializeField]
    private float _fireRate = 0.1f;
    [SerializeField]
    GameObject _shieldObject;

    bool tripleShootEnabled;
    bool speedBoostEnabled;
    bool shieldEnabled;

    private int _score = 0 ;
    
    void Update()
    {
        CalclulateMovement();
        ShootBullet();    
    }

    void CalclulateMovement()
    {

        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = -Input.GetAxis("Vertical");
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
            GameObject _bullet;
            if (tripleShootEnabled == true)
            {
                _bullet = Instantiate(_tripleBulletPrefab) as GameObject;
            }
           else
            {
                _bullet = Instantiate(_bulletPrefab) as GameObject;
            }
            _bullet.transform.position = transform.position + new Vector3(0f, 0.85f, 0f);
        }
    }
    [SerializeField]
    private int _playerLifes = 3;
    [SerializeField]
    private SpawingManager _spawningManager;
    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    private GameManager _gameManager;
    public void DamagePlayer()
    {
        if (shieldEnabled)
        {
            shieldEnabled = false;
            Disable_PowerUp_Shield();
            return;
        }
        _playerLifes--;
        _uiManager.UpdatePlayerLives(_playerLifes);
        if (_playerLifes == 0)
        {
            _spawningManager.OnPlayerDeath();
            _uiManager.ShowGameOver();
            _gameManager.GameOver();
            Destroy(this.gameObject);
            
        }
    }

    public void PowerUp_TripleShoot()
    {
        tripleShootEnabled = true;
        StartCoroutine(Disable_PowerUp_TripleShoot());
    }

    IEnumerator Disable_PowerUp_TripleShoot()
    {
        yield return new WaitForSeconds(5f);
        tripleShootEnabled = false;
    }

    public void PowerUp_SpeedBoost()
    {
        speedBoostEnabled = true;
        _playerMovementSpeed *= 2;
        StartCoroutine(Disable_PowerUp_SpeedBoost());
    }

    IEnumerator Disable_PowerUp_SpeedBoost()
    {
        yield return new WaitForSeconds(5f);
        _playerMovementSpeed /= 2;
        speedBoostEnabled = false;
    }

    public void PowerUp_Shield()
    {
        _shieldObject.SetActive(true);
        shieldEnabled = true;

    }

    void Disable_PowerUp_Shield()
    {
        shieldEnabled = false;
        _shieldObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        _score += score;
        _uiManager.UpdateScoreText(_score);
    }
}

