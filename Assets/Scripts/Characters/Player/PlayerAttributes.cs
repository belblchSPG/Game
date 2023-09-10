using UnityEngine;

namespace RPG
{
    public class PlayerAttributes : MonoBehaviour
    {
        [Header("Health Parameters")]
        [SerializeField] private float _playerCurrentHealth = 100f;
        [SerializeField] private float _playerMaxHealth = 100f;
        [SerializeField] private float _playerHealthRegen = 1f;
        [SerializeField] private bool _needRegenHealth = false;
        [SerializeField] private bool _isDead = false;

        [Header("Stamina Parameters")]
        [SerializeField] private float _playerCurrentStamina = 100f;
        [SerializeField] private float _playerMaxStamina = 100f;
        [SerializeField] private float _playerStaminaRegen = 1f;
        [SerializeField] private bool _needRegenStamina = false;

        [Header("Mana Parameters")]
        [SerializeField] private float _playerCurrentMana = 100f;
        [SerializeField] private float _playerMaxMana = 100f;
        [SerializeField] private float _playerManaRegen = .5f;
        [SerializeField] private bool _needRegenMana = false;

        [Header("Stats")]
        [SerializeField] private float _playerStrength;
        [SerializeField] private float _playerAgility;
        [SerializeField] private float _playerIntelligence;

        [Header("Level Parameters")]
        [SerializeField] private int _playerLevel = 1;
        [SerializeField] private int _playerExperience = 0;

        private void Update()
        {
            if (_isDead) return;
            if (_needRegenHealth)
            {
                RegenHealth();
            }
            if (_needRegenStamina)
            {
                RegenStamina();
            }
            if (_needRegenMana)
            {
                RegenMana();
            }
        }

        #region Health
        private void RegenHealth()
        {
            if (_playerCurrentHealth < _playerMaxHealth)
            {
                _playerCurrentHealth += _playerHealthRegen * Time.deltaTime;
                return;
            }
            _playerCurrentHealth = _playerMaxHealth;
            _needRegenHealth = false;
        }

        public float GetCurrentHealth()
        {
            return _playerCurrentHealth;
        }

        public float GetMaxHealth()
        {
            return _playerMaxHealth;
        }

        private void TakeDamage(float damage)
        {
            if (damage >= _playerCurrentHealth)
            {
                _isDead = true;
                _needRegenHealth = false;
                return;
            }
            _playerCurrentHealth -= damage;

            if (_playerCurrentHealth < _playerMaxHealth)
            {
                _needRegenHealth = true;
            }
        }

        #endregion

        #region Stamina
        public float GetCurrentStamina()
        {
            return _playerCurrentStamina;
        }

        public float GetMaxStamina()
        {
            return _playerMaxStamina;
        }

        public void ReduceStamina(float reduceValue)
        {
            if (reduceValue == _playerCurrentStamina)
            {
                _playerCurrentStamina = 0;
                _needRegenStamina = true;
                return;
            }
            if (reduceValue > _playerCurrentMana)
            {
                return;
            }
            _playerCurrentStamina -= reduceValue;
            _needRegenStamina = true;
        }

        private void RegenStamina()
        {

            if (_playerCurrentStamina < _playerMaxStamina)
            {
                _playerCurrentStamina += _playerStaminaRegen * Time.deltaTime;
                return;
            }
            _playerCurrentStamina = _playerMaxStamina;
            _needRegenStamina = false;
        }

        #endregion

        #region Mana

        public float GetCurrentMana()
        {
            return _playerCurrentMana;
        }

        private void RegenMana()
        {
            if (_playerCurrentMana < _playerMaxMana)
            {
                _playerCurrentMana += _playerManaRegen * Time.deltaTime;
                return;
            }
            _playerCurrentMana = _playerMaxMana;
            _needRegenMana = false;
        }

        #endregion

        public void AddExperience(int value)
        {
            Debug.Log("added exp");
            _playerExperience += value;
        }
    }
}