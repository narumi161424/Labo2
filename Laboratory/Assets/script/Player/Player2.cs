using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    // 方向
    public enum Direction
    {
        Left, //左
        Right //右
    }


    public Direction Dir { get; private set; }

    // プレイヤーのインスタンスを管理する static 変数
    public static Player2 m_instance;

    public float moveSpeed;

    Rigidbody2D rigid2D;


    public AudioClip gemSound;
    private Vector3 defalutScale = Vector3.one;

    private AudioSource sound01;


    public GameObject Attack;


    public int m_hpMax; // HP の最大値
    public int m_hp; // HP
    public int m_damage;


    // Use this for initialization
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        sound01 = GetComponent<AudioSource>();

    }


    //左右のショット
    [SerializeField]
    UbhBaseShot[] shots;

    // ダメージを受ける関数
    // 敵とぶつかった時に呼び出される
    public void Damage(int damage)
    {

        Debug.Log("Player damage called");

        Debug.Log(damage);

        // HP を減らす
        m_hp -= damage;

        Debug.Log(m_hp);

        //ダメージを受けた時の見た目変化
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Damage");

        //ダメージ音
        sound01.PlayOneShot(sound01.clip);

       
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
        Dir = Direction.Right; // 方向
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
        Attack.SetActive(!GameDirector.Instance.IsPause);

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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左
            //Debug.Log("Left");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * -1.0f * moveSpeed;
            Dir = Direction.Left;
        }
        else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右

            //Debug.Log("Right");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * moveSpeed;
            Dir = Direction.Right;
        }

        //方向に合わせて弾の発射方向も選ぶ
        for (int i = 0; i < shots.Length; ++i)
            shots[i].gameObject.SetActive((int)Dir == i);

        //方向に合わせてキャラの見た目変化
        var animator = GetComponent<Animator>();
        animator.SetBool("_Right", Dir == Direction.Right);
        animator.SetBool("_Left", Dir == Direction.Left);

        //      animator.SetBool("_Attack", Input.GetKey(KeyCode.Space));
    }
}

