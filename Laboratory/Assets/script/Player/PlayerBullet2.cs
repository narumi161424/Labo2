using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet2: MonoBehaviour {



    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {


        // 弾と衝突した場合
        if (collision.name.Contains("teresa"))
        {

            //敵にダメージを与える


            //爆発を作る
            //var bom = Instantiate(MobRoot.Instance.Bom, transform.parent);
            //bom.transform.position = transform.position;




            Debug.Log(collision.gameObject.GetComponent<TeresaDamege>());

            collision.gameObject.GetComponent<TeresaDamege>().Damage(3);



            // 敵を削除する
            Destroy(gameObject);

        }

    }
}
