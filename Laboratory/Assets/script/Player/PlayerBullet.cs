using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{




    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {


        //ポーズ中ならまるまる処理を飛ばす
        if (GameDirector.Instance.IsPause)
            return;

        // 弾と衝突した場合
        if (collision.name.Contains("KaruaBoss"))
        {

            //敵にダメージを与える




            Debug.Log(collision.gameObject.GetComponent<EnemyDamege>());

            collision.gameObject.GetComponent<EnemyDamege>().Damage(30);



            // 敵を削除する
            Destroy(gameObject);

        }

    }
}
