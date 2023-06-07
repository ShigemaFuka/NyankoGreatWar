using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    [SerializeField] float _speed;
    //[Tooltip("CharaHp�̃t���O")] bool _isTouch;
    CharaHp _charaHp;
    [SerializeField] Vector2 _powerDirection = Vector2.up;
    [SerializeField] float _powerScale = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _charaHp = this.gameObject.GetComponent<CharaHp>();
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Push()���s�v�Ȏ�
        if (_charaHp._isTouch != true)
        {
            // �������Ɉړ�
            _rigidbody2D.velocity = new Vector2(-_speed, 0);
        }
    }

    public void Push()
    {
        // ��������ɒe���悤�ɂ���
        _rigidbody2D.AddForce(_powerDirection * _powerScale, ForceMode2D.Impulse);
    }
}
