using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private GameObject gameOverText;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void StopSpawn()
    {
        Destroy(enemySpawn);
        gameOverText.SetActive(true);
    }
}
