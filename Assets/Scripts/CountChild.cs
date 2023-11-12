using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �q�I�u�W�F�N�g�̐���ۗL���Ă���
/// �p�[�e�B�[�̐��𐧌�����
/// �p�[�e�B�[�̑I���G���A�i�e�I�u�W�F�N�g�j�ɃA�^�b�`����
/// </summary>
public class CountChild : MonoBehaviour
{
    [SerializeField, Tooltip("�p�[�e�B�[�̏����")] int _maxPartyNum;
    public int MaxPartyNum { get => _maxPartyNum; set => _maxPartyNum = value; }
    [SerializeField, Tooltip("������")] UnityEvent _onStart;
    [SerializeField, Tooltip("MaxPartyNum�ɂȂ�������s����")] UnityEvent _onThreeChara;


    void Start()
    {
        _onStart.Invoke();
    }

    /// <summary>
    /// �p�[�e�B�[�̃����o�[�̐��𐧌����邽�߂ɕK�v�Ȓl
    /// �e���i�A�C�R�����j�ŃJ�E���g����ƒl�����������Ȃ�
    /// </summary>
    /// <returns>���̃I�u�W�F�N�g�̎q�I�u�W�F�N�g�̐���Ԃ�</returns>
    public int Count()
    {
        return this.transform.childCount;
    }
    void Update()
    {
        if (Count() == MaxPartyNum)
        {
            _onThreeChara.Invoke();
        }
    }
}
