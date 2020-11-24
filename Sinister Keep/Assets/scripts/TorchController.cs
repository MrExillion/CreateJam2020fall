using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public int id;
        
    private void Start()
    {
        EventSystemManager.EventSystemManagerSingleton.onLeverSwitch += OnLeverSwitch;
       
    }

    private void OnLeverSwitch(int id, bool state, int targetId, bool inverseLink, GameObject go)
    {

        if(this.id == go.GetComponent<PropProperties>().targetId2 || this.id == go.GetComponent<PropProperties>().targetId) 
        {
            //gameObject.GetComponent<PropProperties>().value = !gameObject.GetComponent<PropProperties>().value;
            for (int i = 0; i < gameObject.GetComponentsInChildren<ParticleSystem>().Length; i++)
            {
                if (gameObject.GetComponentsInChildren<ParticleSystem>()[i].isStopped)
                {
                    //gameObject.GetComponentsInChildren<ParticleSystem>()[i].Play();
                    

                }
                else
                {
                    //gameObject.GetComponentsInChildren<ParticleSystem>()[i].Stop();
                }
            }

        }

        if (go.GetComponent<PropProperties>().linked)
        {
            if (this.id == go.GetComponent<LeverController>().linkedLever.GetComponent<PropProperties>().targetId2)
            {
                gameObject.GetComponent<PropProperties>().value = (inverseLink == go.GetComponent<LeverController>().linkedLever.GetComponent<PropProperties>().value);

            }
            else if (this.id == go.GetComponent<PropProperties>().targetId2)
            {
                gameObject.GetComponent<PropProperties>().value = (inverseLink == state);

            }
            

        }

    }




    private void Update()
    {

        

        for (int i = 0; i < gameObject.GetComponentsInChildren<ParticleSystem>().Length; i++)
        {
            if (gameObject.GetComponentsInChildren<ParticleSystem>()[i].isStopped && gameObject.GetComponent<PropProperties>().value)
            {
                gameObject.GetComponentsInChildren<ParticleSystem>()[i].Play();

            }
            else if (gameObject.GetComponentsInChildren<ParticleSystem>()[i].isPlaying && !gameObject.GetComponent<PropProperties>().value)
            {
                gameObject.GetComponentsInChildren<ParticleSystem>()[i].Stop();
            }
        }

    }
}
