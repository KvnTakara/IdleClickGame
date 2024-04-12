using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

/// <summary>
///     Gerencia todos os registros do jogo, como a quantidade de dinheiro, clicadores e multiplicadores
/// </summary>
/// 

class SaveData
{
    public int dinheiro;
    public int clicadores;
    public int multiplicadores;
}

public class GameManager : MonoBehaviour
{
    // Dinheiro
    public static int dinheiro = 0;
    static TextMeshProUGUI textoDinheiro;

    // Clicadores
    public static int clicadores = 0;
    public static int custoClicador = 25;

    // Multiplicadores
    public static int multiplicadores = 1;
    public static int custoMultiplicador = 90;

    // Est� sendo usado Awake inv�s do Start porque a fun��o AddDinheiro � est�tica e depende que o
    // texto do dinheiro exista para funcionar. Ent�o deve ser iniciado com certeza antes de todos
    private void Awake()
    {
        // Pega o texto de dinheiro que est� na tela
        textoDinheiro = GameObject.Find("Canvas").transform.Find("Dinheiro").GetComponent<TextMeshProUGUI>();

        AutoSave();
    }

    // A vari�vel de dinheiro poderia ser alterada diretamente, por�m ao usar esta fun��o,
    // o texto do Canvas j� � atualizado ao mesmo tempo
    public static void AddDinheiro(int valor)
    {
        GameManager.dinheiro += valor;
        textoDinheiro.text = "$ " + GameManager.dinheiro.ToString();
    }

    

    void SaveGame()
    {
        SaveData save = new SaveData();
        save.dinheiro = dinheiro;
        save.clicadores = clicadores;
        save.multiplicadores = multiplicadores;

        string saveDataJson = JsonUtility.ToJson(save);
        string fileName = "save.json";
        string filePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + fileName;

        File.WriteAllText(filePath, saveDataJson);
    }

    void LoadGame()
    {
        string fileName = "save.json";
        string filePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + fileName;

        string dados = null;
        if (File.Exists(filePath))
        {
            dados = File.ReadAllText(filePath);
        }

        SaveData save = JsonUtility.FromJson<SaveData>(dados);

        dinheiro = save.dinheiro;
        clicadores = save.clicadores;
        multiplicadores = save.multiplicadores;

        //File.Delete(filePath);
    }

    void AutoSave()
    {
        SaveGame();
        Invoke("AutoSave", 5);
    }
}
