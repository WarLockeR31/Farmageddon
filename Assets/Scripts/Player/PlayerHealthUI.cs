using UnityEngine;
using System.Collections.Generic;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    
    [SerializeField] private Transform redHealthContainer;
    [SerializeField] private Transform yellowHealthContainer;
    [SerializeField] private Transform greenHealthContainer;

    [SerializeField] private GameObject redHealthCellPrefab;
    [SerializeField] private GameObject yellowHealthCellPrefab;
    [SerializeField] private GameObject greenHealthCellPrefab;

    private List<GameObject> redHealthCells = new List<GameObject>();
    private List<GameObject> yellowHealthCells = new List<GameObject>();
    private List<GameObject> greenHealthCells = new List<GameObject>();

    private void Start()
    {
        playerHealth.OnRedHealthChanged.AddListener(UpdateRedHealthUI);
        playerHealth.OnYellowHealthChanged.AddListener(UpdateYellowHealthUI);
        playerHealth.OnGreenHealthChanged.AddListener(UpdateGreenHealthUI);

        InitializeHealthUI();
    }

    private void InitializeHealthUI()
    {
        for (int i = 0; i < playerHealth.maxRedHealth; i++)
        {
            GameObject cell = Instantiate(redHealthCellPrefab, redHealthContainer);
            redHealthCells.Add(cell);
        }

        for (int i = 0; i < playerHealth.maxYellowHealth; i++)
        {
            GameObject cell = Instantiate(yellowHealthCellPrefab, yellowHealthContainer);
            yellowHealthCells.Add(cell);
        }

        for (int i = 0; i < playerHealth.maxGreenHealth; i++)
        {
            GameObject cell = Instantiate(greenHealthCellPrefab, greenHealthContainer);
            greenHealthCells.Add(cell);
        }

        UpdateRedHealthUI();
        UpdateYellowHealthUI();
        UpdateGreenHealthUI();
    }

    private void UpdateRedHealthUI()
    {
        for (int i = 0; i < redHealthCells.Count; i++)
        {
            redHealthCells[i].SetActive(i < playerHealth.CurrentRedHealth);
        }
    }

    private void UpdateYellowHealthUI()
    {
        for (int i = 0; i < yellowHealthCells.Count; i++)
        {
            yellowHealthCells[i].SetActive(i < playerHealth.CurrentYellowHealth);
        }
    }

    private void UpdateGreenHealthUI()
    {
        for (int i = 0; i < greenHealthCells.Count; i++)
        {
            greenHealthCells[i].SetActive(i < playerHealth.CurrentGreenHealth);
        }
    }

    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnRedHealthChanged.RemoveListener(UpdateRedHealthUI);
            playerHealth.OnYellowHealthChanged.RemoveListener(UpdateYellowHealthUI);
            playerHealth.OnGreenHealthChanged.RemoveListener(UpdateGreenHealthUI);
        }
    }
}
