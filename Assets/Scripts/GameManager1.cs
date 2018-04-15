using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    [SerializeField] private List<Collider2D> m_colListCoins = new List<Collider2D>();
    [SerializeField] private Collider2D m_colPlayerBody;
    [SerializeField] private List<Collider2D> m_colListEasterEggs = new List<Collider2D>();
    public static bool g_bEasterEggsFound = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        for (int i = 1; i < m_colListEasterEggs.Count; i++)
        {
            m_colListEasterEggs[i].gameObject.SetActive(false);
        }
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i<m_colListCoins.Count; i++)
        {
            if(m_colListCoins[i].IsTouching(m_colPlayerBody) )
            {
                m_colListCoins[i].gameObject.SetActive(false);
            }
        }

        for(int i = 0;i<m_colListEasterEggs.Count; i++)
        {
            if(m_colListEasterEggs[i].IsTouching(m_colPlayerBody) )
            {
                m_colListEasterEggs[i].gameObject.SetActive(false);
                if(i < m_colListEasterEggs.Count-1)
                {
                    m_colListEasterEggs[i + 1].gameObject.SetActive(true);
                }
                else if(i == m_colListEasterEggs.Count-1)
                {
                    g_bEasterEggsFound = true;
                }
            }
        }

        CheckForWin();
    }

    private void CheckForWin()
    {
        bool bPlayerWin = true; //先假設玩家會過關
        for (int i = 0; i < m_colListCoins.Count && bPlayerWin; i++)
        {
            if (m_colListCoins[i].isActiveAndEnabled)
            {
                bPlayerWin = false; //只要找到有任何一個硬幣還存在的話(尚未被撿起)，那就判斷玩家還沒贏
            }
        }
        if(bPlayerWin)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }        
    }
}
