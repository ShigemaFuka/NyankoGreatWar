using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���HP���X���C�_�ɔ��f
/// HP��0�ŏI���̂��߃V�[���J��
/// �ڐG���Ă����L�����N�^�[�̍U���l�ɉ����ă_���[�W���󂯂�
/// </summary>
public class EnemyCastleHp : MonoBehaviour
{
    [SerializeField] int _maxHp;
    [SerializeField] int _hp;
    [SerializeField, Tooltip("�X���C�_�[")] Slider _hpSlider;
    //Move _move;

    // Start is called before the first frame update
    void Start()
    {
        // HP������
        _hp = _maxHp;
        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _hp;
        //_move = this.gameObject.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Instance.ToClear();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // �L�����̃^�O�t���Ă���ȉ������s
        if (coll.gameObject.tag == "Chara")
        {
            // �L�������ƂɍU���l���قȂ��Ă��Ă��ǂ��悤��
            CharaHp _charaHp = coll.gameObject.GetComponent<CharaHp>();
            // HP���炵�Ă���
            _hp = _hp - _charaHp._attackValue;
            _hpSlider.value = _hp; 

            Debug.Log(_hp + this.gameObject.name);
        }
    }
}
