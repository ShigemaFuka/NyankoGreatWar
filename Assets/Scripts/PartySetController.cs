using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// �h���b�O����I�u�W�F�N�g�ɃA�^�b�`����
/// ���̃I�u�W�F�N�g���q�I�u�W�F�N�g�ɂ��邽�߂̐e�I�u�W�F�N�g���K�v
/// �������A�ǂ����RectTransform���K�v
/// </summary>
public class PartySetController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler
{
    RectTransform _rectTransform = default;
    [Tooltip("�������O�ɏ������Ă����f�b�L")] Transform _originDeck = default;
    [SerializeField, Tooltip("�J�[�h���f�b�L�̊O�ɒu���邩�ǂ����̐ݒ�")] bool _canPutOutOfDeck = false;
    /// <summary>
    /// �e�[�u���I�u�W�F�N�g�i"TableTag" ���t���Ă��� UI �I�u�W�F�N�g�j
    /// ������I�u�W�F�N�g������f�b�L�ł��A���ꂩ��u���f�b�L�ł��Ȃ��G���A��UI�ɓ�����
    /// �f�b�L�Ԃ̈ړ��ɕK�v
    /// </summary>
    GameObject _table = null;
    CountChild _countChild;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _table = GameObject.FindGameObjectWithTag("TableTag");
        _countChild = FindAnyObjectByType<CountChild>();
    }

    /// <summary>
    /// �I�u�W�F�N�g���h���b�O���邾���ŁA�e�q�֌W�͉e���Ȃ�
    /// </summary>
    /// <param name="eventData"></param>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
    }

    /// <summary>
    /// _canPutOutOfDeck���^�̂Ƃ��A�f�b�L�O�ɂ�����悤��
    /// �e�q�֌W��ύX���Ă���
    /// </summary>
    /// <param name="eventData"></param>
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag: {this.name}");
        this.transform.SetParent(_table.transform);
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        var currentDeck = GetCurrentDeck(eventData);
        //�f�b�L�O�ŗ������Ƃ��ɁA���̃f�b�L�ɖ߂�
        if (!_canPutOutOfDeck) _originDeck = currentDeck.transform;
        //�őO�ʂɂȂ�悤�Ƀq�G�����L�[�̉��ɔz�u
        this.gameObject.transform.SetAsLastSibling();
        string message = $"OnPointerDown: {this.name}: ";
        Debug.Log(message);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        var currentDeck = GetCurrentDeck(eventData);
        // �e�I�u�W�F�N�g�ɂ���f�b�L�G���A����������Ȃ���
        // �p�[�e�B�[�̍ő吔�ȏ�̂Ƃ�
        if (currentDeck == null || _countChild.Count() >= _countChild.MaxPartyNum)
        {
            if (!_canPutOutOfDeck)
            {
                // ���O�܂ŋ����f�b�L�ɖ߂�
                this.transform.SetParent(_originDeck);
            }
        }
        else if (currentDeck != null)
        {
            if (currentDeck)
            {
                //�q�I�u�W�F�N�g�ɂ��� 
                this.transform.SetParent(currentDeck.transform);
            }
        }
    }

    /// <summary>
    /// �h���b�O�������̂��ǂ̐e�I�u�W�F�N�g�̎q�I�u�W�F�N�g�ɂ��邩
    /// ���̐e�I�u�W�F�N�g��Ԃ�
    /// </summary>
    /// <param name="eventData"></param>
    /// <returns>�f�b�L�G���A�ɊY������e�I�u�W�F�N�g</returns>
    GameObject GetCurrentDeck(PointerEventData eventData)
    {
        //�e�I�u�W�F�N�g�ɂ�������̂ƁA���̑��h���b�O���Ă�����̓�������List 
        var results = new List<RaycastResult>();
        // �}�E�X�|�C���^�̈ʒu��ɏd�Ȃ��Ă��� UI ��S�� results �Ɏ擾����i���j
        EventSystem.current.RaycastAll(eventData, results);
        // results �ɓ����Ă���I�u�W�F�N�g�̂����ADeckTag(�e�I�u�W�F�N�g�̃^�O) ��
        // �t���Ă���I�u�W�F�N�g����� result �Ɏ擾����
        RaycastResult result = default;
        foreach (var item in results)
        {
            //�e�I�u�W�F�N�g�ɂ�����I�u�W�F�N�g�ɂ����^�O
            //�}�E�X�|�C���^�Ɋ��m�����Ƃ��ɓ���̃^�O���e�I�u�W�F�N�g������Ƃ������Ƃ́A���̏��
            //����̂��̂��h���b�O���Ă���Ƃ�������
            if (item.gameObject.CompareTag("DeckTag"))
            {
                result = item;
                break;
            }
        }
        return result.gameObject;   // ���ʂ� GameObject ��Ԃ�
        //�i���jEventSystem �̃C���^�[�t�F�C�X���g�����ʏ�̃v���O���~���O���ƁA�I�u�W�F�N�g���d�Ȃ��Ă���ꍇ�́u��ԏ�ɕ`�悳��Ă���I�u�W�F�N�g�v�����}�E�X�̓��������o�ł��Ȃ��B
        // ���̂��߁A�f�b�L�̏�ɃJ�[�h���d�Ȃ��Ă���ꍇ�A�f�b�L���Ń}�E�X�̓��������o�ł��Ȃ��B���̂��� EventSystem.current.RaycastAll ���g���K�v���������B
        // ���Ȃ݂� Hierarchy ��ŉ��ɂ��� UI �I�u�W�F�N�g���O�ʂɕ`�悳���B
    }
}
