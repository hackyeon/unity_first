using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }

    InputManager mInput = new InputManager();
    private ResourcesManager mResources = new ResourcesManager();
    public static InputManager Input { get { return Instance.mInput; } }
    public static ResourcesManager Resources { get { return Instance.mResources;}}
    
    void Start()
    {
        Init();
    }

    void Update()
    {
        mInput.OnUpdate();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }

    }
}
