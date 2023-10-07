using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [Tooltip("x������")] float _xValue;
    //GameObject _sliderObj;
    [SerializeField, Tooltip("��ʂ����E�Ɉړ�����X���C�h")] Slider _slider;

    void Start()
    {
        // �ʒu ������
        this.transform.position = new Vector3(-15, 0, -10);

        //// Slider�֌W���Q��
        //_sliderObj = GameObject.Find("Slider"); 
        //_slider = _sliderObj.GetComponent<Slider>();

        // MaxValue��MinValue�����āA�͈͂����߂�
        _slider.maxValue = 0;
        _slider.minValue = -30;
    }

    void Update()
    {
        // Value�ƃJ�����ړ���A��������
        _xValue = _slider.value;
        this.transform.position = new Vector3(_xValue, 0, -10);

    }
}
