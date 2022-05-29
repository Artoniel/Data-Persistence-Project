using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public Text HighScoreText;
    private void Awake()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            PlayerScore.Instance.LoadScore();
        HighScoreText.text = $"Best Score : {PlayerScore.Instance.highScore} ({PlayerScore.Instance.highScoreName})";
        }
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);//Load Main scene
    }
    public void Exit()
    {        
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
