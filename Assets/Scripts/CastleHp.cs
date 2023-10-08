using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���w�̏��HP��0�ɂȂ�����A�Q�[���}�l�W���[�̃Q�[���I�[�o�[�֐����Ăяo��
/// �G�̏�̂�0�ɂȂ�����A�N���A��ʂ�
/// �e��A�G�L�������ڐG���Ă�����AHP���� 
/// </summary>
public class CastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField, Tooltip("�X���C�_�[")] Slider _hpSlider;
    [SerializeField, Tooltip("�^�O���F�_���[�W��^���Ă������")] string _tagName;
    [SerializeField, Tooltip("�G�̏邩�B�^�FClear�A�U�FGameOver")] 
    bool _isEnemyCastle;
    
    void Start()
    {
        // HP������
        _hp = _maxHp;
        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _hp;
    }
    void Update()
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
            if(_isEnemyCastle) GameManager.Instance.ToClear();
            else GameManager.Instance.ToGameOver();
            Debug.Log("�����ŃQ�[���I�[�o�[�̃V�[���֑J�ڂ���");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // �G�̃^�O�t���Ă���ȉ������s
        if (coll.gameObject.CompareTag(_tagName))
        {
            // �G�L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP���炵�Ă���
            _hp = _hp - _charaHp._attackValue;
            _hpSlider.value = _hp;

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
