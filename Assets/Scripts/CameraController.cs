using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Tooltip("x軸方向")] float _xValue;
    //GameObject _sliderObj;
    [SerializeField, Tooltip("画面を左右に移動するスライド")] Slider _slider;

    void Start()
    {
        // 位置 初期化
        this.transform.position = new Vector3(-15, 0, -10);

        //// Slider関係を参照
        //_sliderObj = GameObject.Find("Slider"); 
        //_slider = _sliderObj.GetComponent<Slider>();

        // MaxValueとMinValueを入れて、範囲を決める
        _slider.maxValue = 0;
        _slider.minValue = -30;
    }

    void Update()
    {
        // Valueとカメラ移動を連動させる
        _xValue = _slider.value;
        this.transform.position = new Vector3(_xValue, 0, -10);

    }
}
