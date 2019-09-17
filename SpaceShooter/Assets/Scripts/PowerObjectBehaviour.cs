using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerObjectBehaviour : MonoBehaviour
{
    [SerializeField]
    int _playerIndentifyNumber;

    [SerializeField]
    AudioClip _powerClip;
   
    private void Update()
    {
        if (transform.position.y <= -6.13f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch ( _playerIndentifyNumber)
            {
                case 0:
                    other.GetComponent<PlayerBehavoiur>().PowerUp_TripleShoot();
                    break;
                case 1:
                    other.GetComponent<PlayerBehavoiur>().PowerUp_Shield();
                    break;
                case 2:
                    other.GetComponent<PlayerBehavoiur>().PowerUp_SpeedBoost();
                    break;
            }
            AudioSource.PlayClipAtPoint(_powerClip, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
