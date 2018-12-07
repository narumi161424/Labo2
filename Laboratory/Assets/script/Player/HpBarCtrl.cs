using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBarCtrl : MonoBehaviour
{
    public Player2 _player;
    public Slider _slider;

    void Start()
    {
        _slider.maxValue = _player.m_hpMax;
        _slider.value = _player.m_hp;
    }

    void LateUpdate()
    {
        // HPゲージに値を設定
        _slider.value = _player.m_hp;
    }
}