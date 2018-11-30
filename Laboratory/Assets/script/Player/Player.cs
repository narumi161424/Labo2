using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {




    // プレイヤーのインスタンスを管理する static 変数
        public static Player m_instance;




    public float moveSpeed;

    public GameObject flowObject;  //話す


    Rigidbody2D rigid2D;


    public AudioClip gemSound;
    private Vector3 defalutScale = Vector3.one;


    private AudioSource sound01;



    public int m_hpMax; // HP の最大値
    public int m_hp; // HP
    public int m_damage;




    // ダメージを受ける関数
    // 敵とぶつかった時に呼び出される
    public void Damage(int damage)
    {

        Debug.Log("Player damage called");

        Debug.Log(damage);

        // HP を減らす
        m_hp -= damage;

        Debug.Log(m_hp);

        // HP がまだある場合、ここで処理を終える
        if (0 < m_hp) return;



        // プレイヤーが死亡したので非表示にする

        if (m_hp >= 0)
        {
            Debug.Log("死んでしまった");
            //死んだらゲームオーバー画面に移動

            { SceneManager.LoadScene("gameoverTeresa"); }
        }

        gameObject.SetActive(false);
    }






    // ゲーム開始時に呼び出される関数
    private void Awake()
    {
        // 他のクラスからプレイヤーを参照できるように
        // static 変数にインスタンス情報を格納する
        m_instance = this;

        m_hp = m_hpMax; // HP

    }


    // 向きを変える
    private void Turn(float inputValue)
    {
        
        if (inputValue > 0)
        {
            transform.localScale = defalutScale;
        }


        else if (inputValue < 0)
        {
        }
    }



    // Update is called once per frame
    void Update()
    {

        //ポーズ中ならまるまる処理を飛ばす
        if (GameDirector.Instance.IsPause)
            return;




        //移動キー


        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //上

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Debug.Log("UP");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * moveSpeed;

        }

        //下

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Debug.Log("Down");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * moveSpeed;
        }



        bool isRight = Input.GetKey(KeyCode.RightArrow);
        bool isLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isAttack = Input.GetKey(KeyCode.Space);



        //左
        if (isLeft)
        {

            //Debug.Log("Left");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * -1.0f * moveSpeed;

        }

        //右
        if (isRight)
        {

            //Debug.Log("Right");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;

        }




        //方向に合わせてキャラの見た目変化


        isRight = !isLeft;

        var animator = GetComponent<Animator>();


        animator.SetBool("_Right", isRight);
        animator.SetBool("_Left", isLeft);
        animator.SetBool("_Attack", isAttack);
    }



}

