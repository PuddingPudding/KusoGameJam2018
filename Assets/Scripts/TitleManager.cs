using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject m_gobjNormalBian;
    [SerializeField] private GameObject m_gobjSecondBian;
    [SerializeField] private Text m_textStory;
    [SerializeField] private GameObject m_gobjFirstLook;
    private bool m_bShowingStory = false;
    // Use this for initialization
    void Start()
    {
        m_gobjSecondBian.SetActive(false);
        m_textStory.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_bShowingStory && Input.GetMouseButtonUp(0) )
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    public void ShowStory()
    {
        m_gobjFirstLook.SetActive(false);
        m_gobjNormalBian.SetActive(false);
        m_gobjSecondBian.SetActive(true);
        m_textStory.gameObject.SetActive(true);
        Invoke("SwitchShowingStory", 1);
    }
    private void SwitchShowingStory()
    {
        m_bShowingStory = true;
    }
}
