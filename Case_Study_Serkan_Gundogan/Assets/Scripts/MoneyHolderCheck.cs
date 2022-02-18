using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHolderCheck : MonoBehaviour
{
    public GameObject bigMoney;
    public GameObject money;
    public GameObject littleMoney;

    public GameObject endGameParticle;
    public GameObject nextLevelScreen;
    bool bigM = false;
    bool midM = false;
    bool smallM = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigMoney"))
        {
            Destroy(other.gameObject);
            Debug.Log("BigMoneyEnter");
            bigMoney.SetActive(true);
            bigM = true;
            Debug.Log($"Big: {bigM} Mon: {midM} Small:{smallM}");
        }

        if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            money.SetActive(true);
            Debug.Log("Money");
            midM = true;
            Debug.Log($"Big: {bigM} Mon: {midM} Small:{smallM}");
        }
        if (other.gameObject.CompareTag("LittleMoney"))
        {
            Destroy(other.gameObject);
            littleMoney.SetActive(true);
            Debug.Log("LittleMoney");
            smallM = true;
            Debug.Log($"Big: {bigM} Mon: {midM} Small:{smallM}");
        }
    }


    private void Update()
    {
        if (bigM == true && midM == true && smallM == true)
        {
            foreach(Transform child in endGameParticle.transform)
            {
                child.GetComponent<ParticleSystem>().Play();
            }
            nextLevelScreen.SetActive(true);
        }
    }
}
