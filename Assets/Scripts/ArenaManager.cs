using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArenaManager : MonoBehaviour
{
    #region Singleton
    private static ArenaManager instance;

    private void Awake()
    {
        instance = this;
    }
    public static ArenaManager getInstance()
    {
        if (instance == null)
        {
            instance = new ArenaManager();
        }
        return instance;
    }
    #endregion

    [System.Serializable]
    private class Wave
    {
        public List<GameObject> enemies;
    }
    [SerializeField]
    private List<Wave> waves = new List<Wave>();

    [SerializeField]
    private GameObject walls;

    private int enemyCount;
    private int curWaveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        walls.SetActive(false);
        for (int i = 0; i < waves.Count; i++)
        {
            List<GameObject> enemies = waves[i].enemies;
            for (int j = 0; j < enemies.Count; j++)
            {
                enemies[j].SetActive(false);
            }
        }
    }

    public void StartWaves()
    {
        walls.SetActive(true);
        StartWave(curWaveIndex);
    }

    void StartWave(int waveIndex)
    {
        List<GameObject> enemies = waves[waveIndex].enemies;
        enemyCount = enemies.Count;

        for (int i = 0; i < enemyCount; i++)
        {
            enemies[i].SetActive(true);
        }
    }

    public void DecEnemyCount()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
            curWaveIndex++;
            StartWave(curWaveIndex);
        }
    }
}
