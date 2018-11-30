using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{


    public bool m_isFollow; // プレイヤーを追尾する場合 true
    public float m_speed;
    Vector3 initScale;
    Vector3 revScale;


    // Use this for initialization
    void Start()
    {
        initScale = gameObject.transform.localScale;
        revScale = initScale;
        revScale.x *= -1.0f;
    }

    // Update is called once per frame
    void Update()
    {


        // プレイヤーを追尾する場合
        if (m_isFollow)
        {


            //ポーズ中ならまるまる処理を飛ばす
            if (GameDirector.Instance.IsPause)
                return;

            // プレイヤーの現在位置へ向かうベクトルを作成する

            float Angle = Vector3.Angle(transform.localPosition, Player.m_instance.transform.localPosition);


            Vector3 dir = Player.m_instance.transform.localPosition - transform.localPosition;
            dir.Normalize();

            //プレイヤーが存在する方向に移動する
            transform.localPosition += dir * m_speed;


            // プレイヤーが存在する方向を向く
            if (dir.x < 0)
            {
                transform.localScale = initScale;
            }
            else
            {
                transform.localScale = revScale;
            }
            return;




        }



    }
}
