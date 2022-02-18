using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlajChibiObsControl : MonoBehaviour
{
    public GameObject endGameParticle;
    public GameObject nextLevelScreen;
    int objectPool;

    private void Update()
    {

        if (objectPool == 3)
        {
            foreach (Transform child in endGameParticle.transform)
            {
                child.GetComponent<ParticleSystem>().Play();

            }
            nextLevelScreen.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            objectPool--;
            Debug.Log("eklendi");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ring"))
        {
            objectPool++;
            Debug.Log("eklendi");
        }
    }
}
