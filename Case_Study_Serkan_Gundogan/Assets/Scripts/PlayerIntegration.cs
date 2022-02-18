using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntegration : MonoBehaviour
{
    int objCount;
    public GameObject endGameParticle;
    public GameObject nextLevelScreen;
    public GameObject loseScreen;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DetectArea"))
        {
            Destroy(this.gameObject);
            loseScreen.SetActive(true);
        }
        if (other.CompareTag("Pickup"))
        {
            objCount++;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Finish"))
        {
            if (objCount >= 3)
            {
                nextLevelScreen.SetActive(true);
                foreach (Transform child in endGameParticle.transform)
                {
                    child.GetComponent<ParticleSystem>().Play();
                }
            }
            
        }
    }

}
