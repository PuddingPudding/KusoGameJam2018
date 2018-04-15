using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private Text m_textScore;

    // Use this for initialization
    void Start()
    {
        if(GameManager1.g_bEasterEggsFound) //若有找到彩蛋
        {
            m_textScore.text = "遊戲完成度100%!";
        }
    }
    
    public void EndGame()
    {
        Application.Quit();
    }
    public void Rechallenge()
    {
        SceneManager.LoadScene("Init", LoadSceneMode.Single);
    }
}
