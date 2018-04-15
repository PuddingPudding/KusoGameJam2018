using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera m_camMainCam; //主攝影機
    [SerializeField] private GameObject m_gobjPlayer;//玩家
    [SerializeField] private float m_fScaleSpeed = 2;
    [SerializeField] private float m_fPlayerSpeed = 4;
    [SerializeField] private float m_fMaxCamSize = 10;
    [SerializeField] private float m_fMinCamSize = 2;

    // Use this for initialization
    void Start()
    {
        m_camMainCam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float fCamUpper = m_camMainCam.transform.position.y + m_camMainCam.orthographicSize;
        float fCamButton = m_camMainCam.transform.position.y - m_camMainCam.orthographicSize;
        float fCamRight = m_camMainCam.transform.position.x + m_camMainCam.orthographicSize * m_camMainCam.aspect;
        float fCamLeft = m_camMainCam.transform.position.x - m_camMainCam.orthographicSize * m_camMainCam.aspect;

        if (Input.GetKey(KeyCode.Z))
        {
            float fCamSizeChange = m_fScaleSpeed * Time.deltaTime; //紀錄攝影機縮放的量
            m_camMainCam.orthographicSize += fCamSizeChange; //放大攝影機
            if(m_camMainCam.orthographicSize > m_fMaxCamSize)
            {
                m_camMainCam.orthographicSize = m_fMaxCamSize;
            }
            else
            {
                Vector2 v2PlayerMove = Vector2.zero;

                if (m_gobjPlayer.transform.position.y > m_camMainCam.transform.position.y) //如果玩家的位子比攝影機高
                {
                    v2PlayerMove.y += fCamSizeChange;
                }
                else if (m_gobjPlayer.transform.position.y < m_camMainCam.transform.position.y) //如果玩家的位子比攝影機高
                {
                    v2PlayerMove.y -= fCamSizeChange;
                }

                if (m_gobjPlayer.transform.position.x > m_camMainCam.transform.position.x)
                {
                    v2PlayerMove.x += fCamSizeChange * m_camMainCam.aspect;
                }
                else if (m_gobjPlayer.transform.position.x < m_camMainCam.transform.position.x)
                {
                    v2PlayerMove.x -= fCamSizeChange * m_camMainCam.aspect; //這邊移動前記得先把那些數字調成浮點數
                }
                m_gobjPlayer.transform.position += (Vector3)v2PlayerMove;
            }            
        }
        else if (Input.GetKey(KeyCode.X))
        {
            float fCamSizeChange = -m_fScaleSpeed * Time.deltaTime; //紀錄攝影機縮放的量
            m_camMainCam.orthographicSize += fCamSizeChange; //縮小攝影機

            if (m_camMainCam.orthographicSize < m_fMinCamSize)
            {
                m_camMainCam.orthographicSize = m_fMinCamSize;
            }
            else
            {
                Vector2 v2PlayerMove = Vector2.zero;
                if (m_gobjPlayer.transform.position.y > m_camMainCam.transform.position.y) //如果玩家的位子比攝影機高
                {
                    v2PlayerMove.y += fCamSizeChange;
                }
                else if (m_gobjPlayer.transform.position.y < m_camMainCam.transform.position.y) //如果玩家的位子比攝影機高
                {
                    v2PlayerMove.y -= fCamSizeChange;
                }

                if (m_gobjPlayer.transform.position.x > m_camMainCam.transform.position.x)
                {
                    v2PlayerMove.x += fCamSizeChange * m_camMainCam.aspect;
                }
                else if (m_gobjPlayer.transform.position.x < m_camMainCam.transform.position.x)
                {
                    v2PlayerMove.x -= fCamSizeChange * m_camMainCam.aspect; //這邊移動前記得先把那些數字調成浮點數
                }
                m_gobjPlayer.transform.position += (Vector3)v2PlayerMove;
            }            
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 v2PlayerMove = Vector2.zero;
            if (m_gobjPlayer.transform.position.y <= fCamUpper && (m_gobjPlayer.transform.position.x + 0.6f >= fCamRight || m_gobjPlayer.transform.position.x-0.6f <= fCamLeft))
            {
                v2PlayerMove.y += m_fPlayerSpeed * Time.deltaTime;
                m_gobjPlayer.transform.position += (Vector3)v2PlayerMove;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 v2PlayerMove = Vector2.zero;
            if (m_gobjPlayer.transform.position.y >= fCamButton && (m_gobjPlayer.transform.position.x + 0.6f >= fCamRight || m_gobjPlayer.transform.position.x - 0.6f <= fCamLeft))
            {
                v2PlayerMove.y -= m_fPlayerSpeed * Time.deltaTime;
                m_gobjPlayer.transform.position += (Vector3)v2PlayerMove;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 v2PlayerMove = Vector2.zero;
            if ((m_gobjPlayer.transform.position.y - 0.6f <= fCamButton || m_gobjPlayer.transform.position.y + 0.6f >= fCamUpper) && m_gobjPlayer.transform.position.x <= fCamRight)
            {
                v2PlayerMove.x += m_fPlayerSpeed * Time.deltaTime;
                m_gobjPlayer.transform.position += (Vector3)v2PlayerMove;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 v2PlayerMove = Vector2.zero;
            if ((m_gobjPlayer.transform.position.y - 0.6f <= fCamButton || m_gobjPlayer.transform.position.y + 0.6f >= fCamUpper) && m_gobjPlayer.transform.position.x >= fCamLeft)
            {
                v2PlayerMove.x -= m_fPlayerSpeed * Time.deltaTime;
                m_gobjPlayer.transform.position += (Vector3)v2PlayerMove;
            }
        }
    }
}
