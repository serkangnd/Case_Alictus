using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZoneController : MonoBehaviour
{
    public GameObject bigM;
    public int moneyPool;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BigMoney"))
        {
            Destroy(other.gameObject);
            bigM.SetActive(true);
            moneyPool++;
            Debug.Log(moneyPool.ToString());
            Debug.Log("Bigmoney entered");
        }
    }
}
