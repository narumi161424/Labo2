using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public float speed = 5;
    public int spriteCount = 1;
    public GameObject front;
    public float xMin = -8.0f;

    void Update()
    {
        // 左へ移動
        transform.position += Vector3.left * speed * Time.deltaTime;

        if ( transform.position.x < xMin){
            float width = front.GetComponent<SpriteRenderer>().bounds.size.x;
            transform.position = new Vector3(front.transform.position.x + width,
                                             front.transform.position.y,
                                             front.transform.position.z);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    /*
    void OnBecameInvisible()
    {
        float width = front.GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = new Vector3(front.transform.position.x + width,
                                         front.transform.position.y,
                                         front.transform.position.z);
        // スプライトの幅を取得
        // float width = GetComponent<SpriteRenderer>().bounds.size.x;
        // 幅ｘ個数分だけ右へ移動
        //transform.position += Vector3.right * width * spriteCount;
    }
    */
}