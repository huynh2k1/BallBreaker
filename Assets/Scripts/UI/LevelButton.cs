using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelButton : MonoBehaviour
{
     public int levelGoto;
    public bool isUnlocked;
    public GameObject levelState;
    public Image icon;
    public Text levelText;
    public Sprite checkMask; //icon tick để thay cho icon khóa khi level đã hoàn thành
    public Sprite lockIcon;
    Button m_btnComp;
    private void Start()
    {
        //Nếu text trong button không null
        if(levelText != null)
            levelText.text = (levelGoto + 1).ToString("00");

        if(!Prefs.IsGameEntered())
        {
            Prefs.SetLevelUnlocked(levelGoto, isUnlocked);
        }
        //Nếu level đã được mở khóa
        if(Prefs.IsLevelUnlocked(levelGoto))
        {
            if(levelState != null)
            {
                // Tắt trạng thái lock level
                levelState.SetActive(false);
            }
            if(Prefs.IsLevelPassed(levelGoto))
            {
                //Nếu mà đã qua level này
                if(levelState)
                //Bật level state
                    levelState.SetActive(true);

                if(icon && checkMask)
                {
                //Thay icon khóa bằng icon tick
                    icon.sprite = checkMask;
                }
            }
        }
        //Ngược lại thì set icon lock cho level này
        else
        {
            if(levelState)
                levelState.SetActive(true);
            if(icon && lockIcon)
                icon.sprite = lockIcon;
        }
    }
    public void GotoLevel()
    {
        if(Prefs.IsLevelUnlocked(levelGoto))
        {
            LevelManager.Ins.CurLevel = levelGoto;
            SceneManager.LoadScene(SceneConsts.GAME_PLAY);
        }
    }
    public void SelectLevel()
    {
        m_btnComp = GetComponent<Button>();

        if(m_btnComp)
        {
            m_btnComp.onClick.AddListener(() => GotoLevel());
        }
    }
}
