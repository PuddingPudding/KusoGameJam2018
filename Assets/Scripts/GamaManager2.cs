using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamaManager2 : MonoBehaviour
{
    [SerializeField] private List<Collider2D> m_colListEnemy = new List<Collider2D>();
    [SerializeField] private GameObject m_gobjCoinPrefab; //錢幣的遊戲物件
    [SerializeField] private Collider2D m_colPlayer; //錢幣的遊戲物件
    [SerializeField] private int m_iCoinNum = 3;
    [SerializeField] private Text m_textCoinLeft;
    [SerializeField] private GameObject m_gobjGameOverView;
    private List<Collider2D> m_colListCoins = new List<Collider2D>();
    private bool m_bGaming = true;

    // Use this for initialization
    void Start()
    {
        m_bGaming = true;
        Time.timeScale = 1;
        m_gobjGameOverView.SetActive(false);
        for (int i = 0; i < m_iCoinNum; i++)
        {
            float fSpawnX = Random.Range(-15f, 15f);
            float fSpawnY = Random.Range(-8f, 8f);
            Vector2 v2SpawnPoint = new Vector2(fSpawnX, fSpawnY);
            GameObject gobjCoinTemp = GameObject.Instantiate(m_gobjCoinPrefab);
            gobjCoinTemp.transform.position = v2SpawnPoint;
            m_colListCoins.Add(gobjCoinTemp.GetComponent<Collider2D>());
        }
        m_textCoinLeft.text = "剩餘金幣: " + this.GetCoinLeft();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForGaming();
    }

    private void CheckForGaming()
    {
        for(int i = 0; i< m_colListEnemy.Count && m_bGaming ; i++)
        {
            if(m_colListEnemy[i].IsTouching(m_colPlayer) )
            {
                Time.timeScale = 0;
                m_gobjGameOverView.SetActive(true);
                m_bGaming = false;
            }
        }
        for(int i = 0; i<m_colListCoins.Count && m_bGaming; i++)
        {
            if(m_colListCoins[i].IsTouching(m_colPlayer) )
            {
                m_colListCoins[i].gameObject.SetActive(false);
                m_textCoinLeft.text = "剩餘金幣: " + this.GetCoinLeft();
            }
        }
        if(this.GetCoinLeft() <= 0 && m_bGaming)
        {
            m_bGaming = false;
            DOTween.To(()=>Time.timeScale , x => Time.timeScale = x , 0 , 1.5f).SetUpdate(true).OnComplete(() =>
            {
                SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
            });
        }
    }

    public int GetCoinLeft()
    {
        int output = 0;
        for(int i = 0; i< m_colListCoins.Count ;i++)
        {
            if(m_colListCoins[i].isActiveAndEnabled)
            {
                output++;
            }
        }
        return output;
    }

    public void Restart()
    {
        //SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
        Application.LoadLevel(Application.loadedLevel);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
