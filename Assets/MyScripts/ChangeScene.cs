using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField, Tooltip("ëJà⁄êÊ")] string _sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 
    public void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
