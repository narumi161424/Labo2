using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KaruaHP : MonoBehaviour {

    //敵のHPバー

        
    public EnemyDamege _enemy;
    public Slider _slider;



    void Start()
    {
        _slider.maxValue = _enemy.m_HP;
        _slider.value = _enemy.m_HP;
    }

    void LateUpdate()
    {
        // HPゲージに値を設定
        _slider.value = _enemy.m_HP;
    }
}

