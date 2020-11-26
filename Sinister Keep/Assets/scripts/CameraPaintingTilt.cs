using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPaintingTilt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Puzzle2Logic.singleton.puzzleObjects[4].GetComponent<PropProperties>().value)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0f,90f,-205f);
//            Debug.Log("default");
        }
        else
        {
            gameObject.transform.localRotation = Quaternion.Euler(0f, 90f, 180f);
        }


    }
}
