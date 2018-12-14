using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    //生成するゲームオブジェクト
    public GameObject Attack;

    void Update()
    {
        //スペースを押したら
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Instantiate( 生成するオブジェクト,  場所, 回転 );  回転はそのままなら↓
            Instantiate(Attack, new Vector3(1.0f, 2.0f, 0.0f), Quaternion.identity);
        }
    }
}