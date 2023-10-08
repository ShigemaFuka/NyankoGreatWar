using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �R�X�g����
///���Ԍo�߂ŃR�X�g�����܂�
///�R�X�g���~���x�����グ��ƁA���~�z�̏�����オ��
///�O���[�h���グ��ɂ́A���z�������K�v������
///�R�X�g������ăL�����N�^�[�𐶐����� 
/// �������
///
///GM���Ŏ��Ԍv�Z�A�����ǂݎ���ăR�X�g�v�Z�A
///�L�����������ŃR�X�g��ǂݎ��A�R�X�g�ƃC���^�[�o�����������ꂽ�琶���\�ɂ��A
///�R�X�g�Ǘ����ŃR�X�g����̊֐������A�L�����������ł�����Q�Ƃ���
///�ő�R�X�g�𒴂�������Z�����(TimerFlag��GM�ŗp��)�A�]����؂�̂Ă�
///
/// ����*���Z��
/// </summary>
public class CostController : MonoBehaviour
{
    [SerializeField, Tooltip("�ő�R�X�g")] float _maxCost = 10000;
    [SerializeField, Tooltip("���݂ۗ̕L�R�X�g")] float _nowMaxCost = 1000;
    public float NowMaxCost { get => _nowMaxCost; set => _nowMaxCost = value; }
    [SerializeField, Tooltip("�����̍ő�R�X�g")] float _initialMaxCost;
    [SerializeField, Tooltip("���݂ۗ̕L�R�X�g")] float _nowHadCost;
    public float NowHadCost { get => _nowHadCost; set => _nowHadCost = value; }
    [SerializeField, Tooltip("���Z�����")] float _addCost = 21.2f;
    [SerializeField, Tooltip("�R�X�g�\���̃e�L�X�g")] Text _nowText;
    [SerializeField, Tooltip("�ő�R�X�g�\���̃e�L�X�g")] Text _nowMaxText;
    [SerializeField, Tooltip("�ő�R�X�g�����̃t���O")] bool _costGreadUp = false;
    [SerializeField, Tooltip("�O���[�h�A�b�v�ɕK�v�ȃR�X�g")]
    void Start()
    {
        NowHadCost = 0;
        _nowText.text = $"{NowHadCost}";
        _nowMaxText.text = $":{NowMaxCost}";
    }

    void Update()
    {
        //���Ԍo�߂ƂƂ��Ɍ��݂ۗ̕L�R�X�g�𑝂₷
        //if(NowHadCost < NowMaxCost) NowHadCost = GameManager.Instance.Timer * _addCost;
        if(NowHadCost < NowMaxCost) NowHadCost += Time.deltaTime * _addCost;
        _nowText.text = $"{NowHadCost.ToString("00000")}";
        _nowMaxText.text = $":{NowMaxCost.ToString("00000")}";
    }

    /// <summary>
    /// �g�p���ɃR�X�g������� 
    /// </summary>
    /// <param name="charaCost">��������L�����̃R�X�g</param>
    public void UseNowHadCost(float charaCost)
    {
        NowHadCost -= charaCost;
    }
    /// <summary>
    /// �L�����̃R�X�g�ȏ�ɕۗL�R�X�g�����邩�ۂ�
    /// </summary>
    /// <param name="charaCost">��������L�����̃R�X�g</param>
    public bool JudgeCostValue(float charaCost)
    {
        if(0 <= NowHadCost - charaCost) return true;
        else return false;
    }
    /// <summary>
    /// ���~�R�X�g�̗ʂ𑝉�
    /// �O���[�h���グ��ۂɁA�ۗL�R�X�g����萔�����
    /// </summary>
    public void GreadUpMaxCost()
    {
        if (_maxCost > _nowMaxCost)
        {
            _nowMaxCost *= 1.5f;
        }
        //���Z���_maxCost���I�[�o�[���Ă��␳����
        if (_maxCost <= _nowMaxCost) _nowMaxCost = _maxCost;
    }
}