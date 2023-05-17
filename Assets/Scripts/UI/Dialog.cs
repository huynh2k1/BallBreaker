using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    // public Button m_btnComp;
    private void Start() {
        // m_btnComp = GetComponent<Button>();
    }
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
    
}
