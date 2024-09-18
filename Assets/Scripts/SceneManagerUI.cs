using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManagerUI : MonoBehaviour
{
    public TMP_InputField nomePlayer;
    public TextMeshProUGUI lastScoreName;
    private string nomeText;
    private GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        // Exibir o Best Score e o nome do jogador
        lastScoreName.text = GameManager.Instance.bestPlayerName + " - " + GameManager.Instance.bestScore;
    }
    public void SetPlayerName()
    {
        GameManager.Instance.playerName = nomePlayer.text; // Salva o nome no GameManager
        GameManager.Instance.bestPlayerName = nomePlayer.text; // Define o nome do melhor jogador, se for necessário
    }

    public void ChamaCena(string nomeCena)
    {
        
        SceneManager.LoadScene(nomeCena);
    }

    

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
