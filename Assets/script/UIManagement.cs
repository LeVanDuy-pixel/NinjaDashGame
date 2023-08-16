using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManagement : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel, guidePanel;

    public void SetScoretext(string txt)
    {
        if(scoreText){
            scoreText.text = txt;
        }
    }
    public void ShowGameOverPanel(bool isShow){
        if(gameOverPanel){
            gameOverPanel.SetActive(isShow);
        }
    }
    public void ShowGameGuidePanel(bool isHide)
    {
        
        if (guidePanel)
        {
            guidePanel.SetActive(isHide);
        }
    }
}
