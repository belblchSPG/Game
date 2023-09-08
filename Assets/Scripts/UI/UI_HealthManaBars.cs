using RPG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthManaBars : MonoBehaviour
{
    [SerializeField] private GameObject _inspectedPlayer;
    [SerializeField] private PlayerAttributes _inspectedAttributes;

    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _staminaBar;



    private void Start()
    {
        _inspectedAttributes = _inspectedPlayer.GetComponent<PlayerAttributes>();
    }

    private void Update()
    {
        UpdateHealth();
        UpdateStamina();
    }

    private void UpdateHealth()
    {
        _healthBar.fillAmount = _inspectedAttributes.GetCurrentHealth() / _inspectedAttributes.GetMaxHealth();
        return;
    }

    private void UpdateStamina()
    {
        _staminaBar.fillAmount = _inspectedAttributes.GetCurrentStamina() / _inspectedAttributes.GetMaxStamina();
        return;
    }
    

}
