using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        LoadGame();
        AutoSave();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Points", GameManager.dinheiro);
        PlayerPrefs.SetInt("Clickers", GameManager.clicadores);
        PlayerPrefs.SetInt("ClickersCost", GameManager.custoClicador);
        PlayerPrefs.SetInt("Multipliers", GameManager.multiplicadores);
        PlayerPrefs.SetInt("MultipliersCost", GameManager.custoMultiplicador);
    }

    void LoadGame()
    {
        GameManager.dinheiro = PlayerPrefs.GetInt("Points");
        GameManager.clicadores = PlayerPrefs.GetInt("Clickers");
        GameManager.custoClicador = PlayerPrefs.GetInt("ClickersCost");
        GameManager.multiplicadores = PlayerPrefs.GetInt("Multipliers");
        GameManager.custoMultiplicador = PlayerPrefs.GetInt("MultipliersCost");
    }

    void AutoSave()
    {
        Invoke("SaveGame", 5);
    }
}