using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    public GameObject endGameParticle;
    public GameObject nextLevelScreen;
    int objCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CannonBall"))
        {
            objCount++;
            if (objCount >= 3)
            {
                foreach (Transform child in endGameParticle.transform)
                {
                    child.GetComponent<ParticleSystem>().Play();
                    nextLevelScreen.SetActive(true);
                }
            }           
        }
    }
}
