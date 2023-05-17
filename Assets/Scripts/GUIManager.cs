using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GUIManager : Singleton<GUIManager>
{
    public static GUIManager Instance;
    public Text score;
    public Dialog loseDialog;
    public Dialog winDialog;
    public Dialog pauseDialog;
    Dialog m_curDialog;
    public Dialog CurDialog {get => m_curDialog; set => m_curDialog = value; }
    public int scoreStart;
    public GameObject dialog;
    LevelButton levelButton;
    private void Awake() {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    private void Start() {
        score.text = "SCORE: " + scoreStart.ToString();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        if(pauseDialog)
        {
            pauseDialog.Show(true);
            m_curDialog = pauseDialog;
        }
    }
    public void Win()
    {
        Time.timeScale = 0;
        if(winDialog)
        {
            winDialog.Show(true);
            m_curDialog = winDialog;
        }
    }
    public void Lose()
    {
        Time.timeScale = 0;
        if(loseDialog)
        {
            loseDialog.Show(true);
            m_curDialog = loseDialog;
        }
    }
    public void RestartGame()
    {
        levelButton.SelectLevel();
        if(m_curDialog)
            m_curDialog.Show(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if(m_curDialog)
            m_curDialog.Show(false);
    }
    public void BackToHome()
    {
        // ResumeGame();
        SceneManager.LoadScene(SceneConsts.MAIN);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
