using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _playerLives;
    [SerializeField]
    private List<Sprite> _lives;
    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private GameObject _restartGameText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText(0);
        UpdatePlayerLives(3);
        _gameOverText.SetActive(false);
        _restartGameText.SetActive(false);
    }

    public void UpdateScoreText(int score)
    {
        _scoreText.text = "Score : " + score;
    }

    public void UpdatePlayerLives(int playerLives)
    {
        _playerLives.sprite = _lives[playerLives];
    }

    public void ShowGameOver()
    {
        StartCoroutine(FlatulateGameOverText());
        _restartGameText.SetActive(true);
    }

    WaitForSeconds _wait = new WaitForSeconds(0.5f); 
    IEnumerator FlatulateGameOverText()
    {
        while(true)
        {
            _gameOverText.SetActive(true);
            yield return _wait;
            _gameOverText.SetActive(false);
            yield return _wait;
        }
        
    }
}
