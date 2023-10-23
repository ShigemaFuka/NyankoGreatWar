using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �q�I�u�W�F�N�g��Id���擾���AGM�̕ϐ��ɓ����
/// </summary>
public class GetSetCharaIds : MonoBehaviour
{
    [SerializeField, Tooltip("�I�����ꂽId")] List<string> _ids;
    [SerializeField] GameManager gm; //���܂�Missing�ɂȂ�
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    /// <summary>
    /// GM�̕ϐ���Id������
    /// </summary>
    public void OnClick()
    {
        GetSetIds();
    }

    /// <summary>
    /// ��I�u�W�F�N�g�ɔz�u�i�q�I�u�W�F�N�g���j�������̂�
    /// �p�[�e�B�[�ɑI�������Ƃ݂Ȃ��AID�����ݒ肵���X�N���v�g��ID�ǂݎ��A
    /// ������̔z��ɓ��ꂽ���ƁAGM�̕�����̃��X�g�ɓ����
    /// �p�[�e�B�[�̏�������J��Ԃ�
    /// </summary>
    void GetSetIds()
    {
        for (var i = 0; i < _ids.Count; i++)
        {
            var go = transform.GetChild(i);
            var charaIds = go.GetComponent<CharaIds>();
            this._ids[i] = charaIds.Id.ToString();
            //GameManager.Instance.IDs.Add(this._ids[i]); 
            //�����ꂾ�ƁAStart�V�[������J�n���Đ퓬�V�[���ɑJ�ڂ����Ƃ���Null�ɂȂ���
            //Debug.Log("GameManager.Instance.IDs[i]" + GameManager.Instance.IDs[i]);
            
            gm.IDs.Add(this._ids[i]);
            Debug.Log("gm.IDs[i]" + gm.IDs[i]);
            //gm�����܂�Missing�ɂȂ�
        }
    }
}
