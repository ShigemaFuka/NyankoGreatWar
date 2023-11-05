using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �L�����̃p�����[�^���A�}�E�X�J�[�\�������������Ƃ��ɁA�\������
/// �������ꂽ��A�֐����Ăяo��
/// �֐��̏������e�F�l�����o���āA�e�p�����[�^�\���e�L�X�g�ɁAString�Œl��n��
/// �p�����[�^�̐e�I�u�W�F�N�g�ɁA���̃X�N���v�g���������A�e�L�����̃A�C�R����UnityEvent����Ăяo��
/// </summary>
public class TakeAndShowParamator : MonoBehaviour
{
    [SerializeField, Tooltip("�U���l")] Text _attack;
    [SerializeField, Tooltip("�̗͒l")] Text _hp;
    [SerializeField, Tooltip("�����R�X�g")] Text _cost;
    [SerializeField, Tooltip("�ړ����x")] Text _speed;
    [SerializeField, Tooltip("������ѓx")] Text _selfImpactPower;
    [SerializeField, Tooltip("�����C���^�[�o��")] Text _interval;
    [SerializeField, Tooltip("�L�����f�[�^�ꗗ�i�C���^�[�o���Q�Ƃ̂��߁j")] CharacterDataAchievementList _characterDataAchievementList = null;

    /// <summary>
    /// �e�L�X�g���������i�l�̔�\���j
    /// </summary>
    void Start()
    {
        _attack.text = "";
        _hp.text = "";
        _cost.text = "";
        _speed.text = "";
        _selfImpactPower.text = "";
        _interval.text = "";
    }

    /// <summary>
    /// �e�L�����̃A�C�R���Ƀ}�E�X�J�[�\�����A
    /// �������ꂽ�Ƃ��ɌĂ΂��֐�
    /// </summary>
    /// <param name="cData">CharaIds�ɃA�^�b�`�����e�L�����̃f�[�^</param>
    public void SetParamator(CharacterData cData)
    {
        _attack.text = cData.Attack.ToString();
        _hp.text = cData.Maxhp.ToString();
        _cost.text = cData.Cost.ToString();
        _speed.text = cData.Speed.ToString();
        _selfImpactPower.text = cData.SelfImpactPower.ToString();
    }

    /// <summary>
    /// id��_characterDataAchievementList���猟�����āA�C���^�[�o�����擾������
    /// </summary>
    /// <param name="charaIds">�A�C�R���L�����ɃA�^�b�`����CharaIds�X�N���v�g</param>
    public void SetInterval(CharaIds charaIds)
    {
        for (var i = 0; i < _characterDataAchievementList.achievementList.Count; i++)
        {
            if (_characterDataAchievementList.achievementList[i].Id.ToString() == charaIds._characterData.Id.ToString())
                _interval.text = _characterDataAchievementList.achievementList[i].Interval.ToString();        
        }
    }

    public void Reset()
    {
        Start();
    }
}
