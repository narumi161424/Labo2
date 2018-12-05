using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2: MonoBehaviour 
{



    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //ポーズ中ならまるまる処理を飛ばす
        if (GameDirector.Instance.IsPause)
            return;


        // 敵と衝突した場合
        if (collision.name.Contains("teresa"))
        {

            //敵にダメージを与える
            //Debug.Log(collision.gameObject.GetComponent<Player>());
            if (collision.gameObject.GetComponent<TeresaDamege>() != null)
            {
                collision.gameObject.GetComponent<TeresaDamege>().Damage(3);
            }





            // 敵を削除する
            Destroy(gameObject);

        }

    }
}
