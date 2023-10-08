using UnityEngine;

/// <summary>
/// GameManagerを子オブジェクトにして各シーンから参照できるようにする 
/// </summary>
public class SingletonSystem : MonoBehaviour
{
    [Tooltip("インスタンスを取得するためのパブリック変数")] public static SingletonSystem Instance = default;

    void Awake()
    {
        // この処理は Start() に書いてもよいが、Awake() に書くことが多い。
        // 参考: イベント関数の実行順序 https://docs.unity3d.com/ja/2019.4/Manual/ExecutionOrder.html
        if (Instance)
        {
            // インスタンスが既にある場合は、破棄する
            Debug.LogWarning($"SingletonSystem のインスタンスは既に存在するので、{gameObject.name} は破棄します。");
            Destroy(this.gameObject);
        }
        else
        {
            // このクラスのインスタンスが無かった場合は、自分を DontDestroyOnload に置く
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
