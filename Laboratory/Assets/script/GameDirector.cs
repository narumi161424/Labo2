using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameDirector : MonoBehaviour
{
    public static GameDirector Instance;

    public Fungus.Flowchart flowChart;

    //ポーズ状態ならtrue
    public bool IsPause;

    // Use this for initialization
    void Start()
    {
        if (Instance != null)
            throw new System.Exception("誰！？:" + gameObject.name);

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // FungusがひとつでもBlockを実行中ならポーズ中
        IsPause = flowChart.GetExecutingBlocks().Count > 0;
    }
}
