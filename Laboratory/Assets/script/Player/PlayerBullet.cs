using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{




    //ダメージ音
    private AudioSource sound01;



    // Use this for initialization
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        sound01 = GetComponent<AudioSource>();

    }



    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {


        //ポーズ中ならまるまる処理を飛ばす
        if (GameDirector.Instance.IsPause)
            return;

        // 敵と衝突した場合
        if (collision.name.Contains("KaruaBoss"))
        {



            //敵にダメージを与える

            Debug.Log(collision.gameObject.GetComponent<EnemyDamege>());
            collision.gameObject.GetComponent<EnemyDamege>().Damage(5);


            //ダメージ音
            sound01.PlayOneShot(sound01.clip);



            // 敵を削除する
            Destroy(gameObject);

        }

    }
}
