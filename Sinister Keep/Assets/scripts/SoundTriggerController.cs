using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        EventSystemManager.EventSystemManagerSingleton.onSoundTrigger += OnSoundTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            EventSystemManager.EventSystemManagerSingleton.SoundTrigger(gameObject);

        }



    }

    private void OnSoundTrigger(GameObject go) { 
            if (go.GetComponent<PropProperties>().interactSound != null)
            {
                if (!go.GetComponent<PropProperties>().interactSound.isPlaying)
                {
                go.GetComponent<PropProperties>().interactSound.Play();
                }
            }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
