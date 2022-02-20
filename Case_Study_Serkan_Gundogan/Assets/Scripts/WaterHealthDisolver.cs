using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaterHealthDisolver : MonoBehaviour
{
    [SerializeField] private WaterHealth health = null;
    [SerializeField] private Renderer[] healthRenderers = new Renderer[0];

    private float targetDissolveValue = 1f;
    private float currentDissolveValue = 1f;

    public GameObject endGameParticleObj;
    public Slider sliderHealth;
    public GameObject healthBarUI;
    public GameObject nextLevelScreen;

    private void OnEnable()
    {
        health.OnHealthChanged += HandleHealthChanged;
    }
    private void OnDisable()
    {
        health.OnHealthChanged -= HandleHealthChanged;
    }

    private void Update()
    {
        currentDissolveValue = Mathf.Lerp(currentDissolveValue, targetDissolveValue, 2f * Time.deltaTime);

        foreach(Renderer renderer in healthRenderers)
        {
            renderer.material.SetFloat("Health", currentDissolveValue);
        }

        if (targetDissolveValue <= 0)
        {
            foreach(Transform child in endGameParticleObj.transform)
            {
                child.GetComponent<ParticleSystem>().Play();
            }

            healthBarUI.SetActive(false);
            Destroy(this.gameObject);
            nextLevelScreen.SetActive(true);
        }
        
        sliderHealth.value = targetDissolveValue;
        
    }

    void HandleHealthChanged(int health, int maxHealth)
    {
        targetDissolveValue = (float)health / maxHealth;
    }
}
