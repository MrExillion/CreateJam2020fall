using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad Singleton;
    
    

    private void Awake()
    {

        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void Update()
    {
        RenderSettings.sun = gameObject.GetComponent<Light>();
        //if (SceneManager.GetActiveScene().buildIndex == 1)
        //{
        //    RenderSettings.sun = gameObject.GetComponent<Light>();
       // }

    }

}
