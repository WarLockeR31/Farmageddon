using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HouseArenaManager : MonoBehaviour
{
    #region Singleton
    private static HouseArenaManager instance;

    private void Awake()
    {
        instance = this;
    }
    public static HouseArenaManager getInstance()
    {
        if (instance == null)
        {
            instance = new HouseArenaManager();
        }
        return instance;
    }
    #endregion

    [System.Serializable]
    private class Wave
    {
        public List<GameObject> enemies;
        public List<GameObject> walls;
    }
    [SerializeField]
    private List<Wave> waves = new List<Wave>();

    [SerializeField]
    private GameObject nextScene;

    private int enemyCount;
    private int curWaveIndex = 0;

    private bool isFighting;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            List<GameObject> enemies = waves[i].enemies;
            for (int j = 0; j < enemies.Count; j++)
            {
                enemies[j].GetComponent<Animator>().enabled = false;
                MonoBehaviour[] enemieScripts = enemies[j].GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour enemy in enemieScripts)
                {
                    enemy.enabled = false;
                }
            }

            List<GameObject> walls = waves[i].walls;
            for (int j = 0; j < walls.Count; j++)
            {
                walls[j].SetActive(false);
            }
        }
    }

    public void StartWaves()
    {
        StartWave(curWaveIndex);
    }

    void StartWave(int waveIndex)
    {
        isFighting = true;
        List<GameObject> enemies = waves[waveIndex].enemies;
        enemyCount = enemies.Count;

        for (int i = 0; i < enemyCount; i++)
        {
            enemies[i].GetComponent<Animator>().enabled = true;
            MonoBehaviour[] enemieScripts = enemies[i].GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour enemy in enemieScripts)
            {
                enemy.enabled = true;
            }
        }

        List<GameObject> walls = waves[waveIndex].walls;
        for (int j = 0; j < walls.Count; j++)
        {
            walls[j].SetActive(true);
        }
    }

    public void DecEnemyCount()
    {
        enemyCount--;
        if (enemyCount == 0)
        {
            isFighting = false;
            List<GameObject> walls = waves[curWaveIndex].walls;
            for (int j = 0; j < walls.Count; j++)
            {
                walls[j].SetActive(false);
            }
            curWaveIndex++;

            if (curWaveIndex == waves.Count)
            {
                nextScene.SetActive(true);
            }
        }
    }

    public bool IsFighting()
    {
        return isFighting;
    }
}
