using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent (typeof(AudioSource))]
public class EnemyDamege : MonoBehaviour
{



   
    public int m_HP;
    public int m_damage;

    //スペル
    public GameObject kiraikirai;
    public GameObject Homing;
    public GameObject yokouti;
    public GameObject mawaru;




    private AudioSource sound01;



    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
       sound01 = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        //止める攻撃

        kiraikirai.SetActive(!GameDirector.Instance.IsPause);
        Homing.SetActive(!GameDirector.Instance.IsPause);
        yokouti.SetActive(!GameDirector.Instance.IsPause);
        mawaru.SetActive(!GameDirector.Instance.IsPause);


        //ポーズ中ならまるまる処理を飛ばす
        if (GameDirector.Instance.IsPause)
            return;

    }


    // 他のオブジェクトと衝突した時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D collision)
    {




        // Debug.Log(collision.name);

        // 弾と衝突した場合
        if (collision.name.Contains("Player_Bullet"))
        {

            Debug.Log(collision.name);

            // 弾が敵に当たったら音を出す
           
          sound01.PlayOneShot(sound01.clip);

            // 弾を削除する
            Destroy(collision.gameObject);

            // 敵の HP を減らす
            m_HP--;

            // 敵の HP がまだ残っている場合はここで処理を終える
            if (0 < m_HP) return;


            //爆発を作る
            //var bom = Instantiate(MobRoot.Instance.Bom, transform.parent);
            //bom.transform.position = transform.position;


            // 敵を削除する
            Destroy(gameObject);

        }
    }

    // ダメージを受ける関数
    //プレイヤーの弾に当たる

    public void Damage(int damage)
    {

        Debug.Log("Karua damage called");

        Debug.Log(damage);

        // HP を減らす
        m_HP -= damage;

        Debug.Log(m_HP);

        // HP がまだある場合、ここで処理を終える
        if (0 < m_HP) return;



        // プレイヤーが死亡したので非表示にする

        if (m_HP <= 0)
        {
            Debug.Log("死んでしまった");
            //死んだらゲームオーバー画面に移動

            { SceneManager.LoadScene("clearKarua"); }
        }

        // Destroy(gameObject);
        gameObject.SetActive(false);
    }


}