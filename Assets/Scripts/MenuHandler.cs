using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_ScoreText;
    TMP_InputField playerNameInput;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        playerNameInput = GameObject.Find("Name Field").GetComponent<TMP_InputField>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        if(ScoreManager.LeaderName.Equals("")){
            scoreManager.LoadHighScore(); 
        }
        m_ScoreText.text = "Best Score: " + ScoreManager.HighScore + ", by "+ScoreManager.LeaderName;
        if(ScoreManager.PlayerName != ""){
            playerNameInput.text = ScoreManager.PlayerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName(string name){
        ScoreManager.PlayerName = name;
    }

    // Launch the game!
    public void StartNew(){
        SceneManager.LoadScene("Main");
    }

    // Quit the app (or exit playmode if running in the Unity Editor)
    public void Exit(){
        if(ScoreManager.HighScore > 0){
            scoreManager.SaveHighScore();
        }

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
