using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacumTrigger : MonoBehaviour
{
    int trashCount;
    public float objectScaleUpSpeed;
    public GameObject endGameParticle;
    public GameObject nextLevelScreen;

    MeshRenderer meshRenderer;
    Color origColor;
    float flashTime = .15f;

    public enum TriggerType
    {
        Trash,
        FlashStop,
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TriggerType.Trash.ToString()))
        {
            Destroy(other.gameObject);
            trashCount++;
            FlashStart();
            MakeBigger();
        }
    }
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        origColor = meshRenderer.material.color;
    }

    private void Update()
    {
        CheckEndGame();
    }

    void FlashStart()
    {
        meshRenderer.material.color = Color.white;
        Invoke(TriggerType.FlashStop.ToString(), flashTime);
    }
    void FlashStop()
    {
        meshRenderer.material.color = origColor;
    }

    void MakeBigger()
    {
        gameObject.transform.localScale += Vector3.one * objectScaleUpSpeed;
    }

    void CheckEndGame()
    {
        if (trashCount >= 4)
        {
            foreach (Transform child in endGameParticle.transform)
            {
                child.GetComponent<ParticleSystem>().Play();
            }
            nextLevelScreen.SetActive(true);
        }
    }
}
