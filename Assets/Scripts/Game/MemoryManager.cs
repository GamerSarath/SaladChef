using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MemoryManager : MonoBehaviour
{

    private static MemoryManager _instance;

    #region Singleton
    public static MemoryManager Instance
    {
        get
        {
            //create logic to create the instance 
            if (_instance == null)
            {
                GameObject go = new GameObject("MemoryManager");
                go.tag = "MemoryManager";
                go.AddComponent<MemoryManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this; // assinging the this object to the _instance ;
        
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        
        yield return new WaitForSeconds(9.0f);
        SceneLoadingManager.Instance.LoadTitleScene(); // Loading the title scene after the splash scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
