﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.R))&& _isGameOver)
        {
            SceneManager.LoadScene(1);

        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
