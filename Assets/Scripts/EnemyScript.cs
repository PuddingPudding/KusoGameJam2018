using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float m_fMoveInterval = 3;
    [SerializeField] private float m_fSpeed = 3.5f;
    private float m_fMoveIntervalCounter = 0;
    private bool m_bIsMoving = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(m_fMoveIntervalCounter <= m_fMoveInterval)
        {
            m_fMoveIntervalCounter += Time.deltaTime;
        }
        else if(!m_bIsMoving)
        {
            m_bIsMoving = true;
            float fDirX = Random.Range(-1f, 1f);
            float fDirY = Random.Range(-1f, 1f);
            Vector2 v2MoveDir = new Vector2(fDirX , fDirY).normalized;
            float fMoveTime = Random.Range(1.5f , 3f);
            Vector3 v3FinalPos = this.transform.position + ((Vector3)v2MoveDir * fMoveTime * m_fSpeed);
            this.transform.DOMove(v3FinalPos, fMoveTime).OnComplete(() =>
            {
                m_bIsMoving = false;
                m_fMoveIntervalCounter -= m_fMoveInterval;
                if(this.transform.position.x >20)
                {
                    this.transform.position = new Vector3(20, this.transform.position.y , 0);
                }
                else if (this.transform.position.x < -20 )
                {
                    this.transform.position = new Vector3(-20, this.transform.position.y, 0);
                }
                if(this.transform.position.y > 12)
                {
                    this.transform.position = new Vector3(this.transform.position.x, 12, 0);
                }
                else if (this.transform.position.y < -12)
                {
                    this.transform.position = new Vector3(this.transform.position.x, -12, 0);
                }
            });
        }
    }
}
