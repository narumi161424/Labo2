using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	
    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //プレイヤーにダメージを与える

        // 弾と衝突した場合
        if (collision.name.Contains("Player"))
        {
            
            //Debug.Log(collision);

            //爆発を作る
            //var bom = Instantiate(MobRoot.Instance.Bom, transform.parent);
            //bom.transform.position = transform.position;



            Debug.Log(collision.gameObject.GetComponent<Player>());
            collision.gameObject.GetComponent<Player>().Damage(5);



            // 敵を削除する
            Destroy(gameObject);

        }

    }
}
