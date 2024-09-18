using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerName;
    public string bestPlayerName = "Carlin"; // Valor inicial padr�o
    public int bestScore = 0;

    public int oldBestScore;
    public int currentScore = 0;

    private void Start()
    {
        LoadNameScore(); // Carregar o nome e pontua��o ao iniciar
    }

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("GameManager already exists.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameManager instance created");
    }

    [System.Serializable]
    class SaveData
    {
        public string nameToSave;
        public int scoreToSave;
    }

    // Fun��o para salvar o nome e a pontua��o
    public void SaveNameScore()
    {
        if (bestScore > oldBestScore)
        {
            Debug.Log("Saving Game");
            SaveData data = new SaveData();
            data.nameToSave = bestPlayerName; // Salva o melhor jogador
            data.scoreToSave = bestScore; // Salva a melhor pontua��o
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/saveNameScore.json", json);
        }
    }

    // Fun��o para carregar o nome e a pontua��o
    public void LoadNameScore()
    {
        Debug.Log("Loading Game");
        string path = Application.persistentDataPath + "/saveNameScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (data.scoreToSave > bestScore)
            {
                bestPlayerName = data.nameToSave; // Define o nome do melhor jogador
                bestScore = oldBestScore = data.scoreToSave; // Define a pontua��o
            }
        }
        else
        {
            Debug.Log("No Json File");
        }
    }
}
