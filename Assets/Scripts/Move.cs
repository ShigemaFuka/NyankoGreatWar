using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    CharaHp _charaHp;
    [SerializeField] Vector2 _powerDirection = Vector2.up;
    [SerializeField, Tooltip("�L�����̃f�[�^")] CharacterData _characterData;
    public CharacterData CharacterData { get => _characterData; set => _characterData = value; }
    [SerializeField] AudioSource _audioSourse;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _charaHp = this.gameObject.GetComponent<CharaHp>();
        _audioSourse = GameObject.Find("SE_Impact").GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        // Push()���s�v�Ȏ�
        if (_charaHp._isTouch != true)
        {
            // �������Ɉړ�
            _rigidbody2D.velocity = new Vector2(-CharacterData.Speed, 0);
        }
    }
    /// <summary>
    /// �e�L�����͐G�ꂽ�u�Ԃ̂ݍU������ɂȂ邽�߁A�ēx�ڐG����K�v������
    /// ���̍ĐڐG���s�����߂ɋ�������点�Ă���
    /// �L�����̃f�[�^�ŉE������A������ɔ�΂������v���}�C�Ō��߂�K�v������
    /// </summary>
    public void Push()
    {
        // ��������ɒe���悤�ɂ���
        _rigidbody2D.AddForce(_powerDirection * CharacterData.SelfImpactPower, ForceMode2D.Impulse);
        _audioSourse.PlayOneShot(_audioSourse.clip);
    }
}
