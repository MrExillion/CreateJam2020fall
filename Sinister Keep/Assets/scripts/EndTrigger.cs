using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    // Start is called before the first frame update


    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(3);
        Cursor.lockState = CursorLockMode.None;
    }
}
