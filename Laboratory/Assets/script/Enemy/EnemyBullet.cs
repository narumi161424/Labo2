using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	
    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        //ポーズ中ならまるまる処理を飛ばす
        if (GameDirector.Instance.IsPause)
            return;

        //プレイヤーにダメージを与える

        // 弾と衝突した場合
        if (collision.name.Contains("Player"))
        {


            //Debug.Log(collision.gameObject.GetComponent<Player>());
            collision.gameObject.GetComponent<Player>();

                collision.gameObject.GetComponent<Player>().Damage(10);
            



            // 敵を削除する
            Destroy(gameObject);

        }

    }
}
