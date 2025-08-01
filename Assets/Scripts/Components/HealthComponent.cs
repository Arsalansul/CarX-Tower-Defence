using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public bool IsAlive => currentHealth > 0;
    public int CurrentHealth => currentHealth;
    private int currentHealth;
    
    public int MaxHealth => maxHealth;
    
    private int maxHealth;
    
    public event System.Action<int> OnHealthChanged;
    public event System.Action OnDeath;
    
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            currentHealth = 0;
        }
    }
    
    public void TakeDamage(int damage)
    {
        if (!IsAlive) return;
        
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);
        
        if (!IsAlive)
        {
            OnDeath?.Invoke();
        }
    }
    
    public void Heal(int amount)
    {
        if (!IsAlive) return;
        
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void OnReturnToPool()
    {
        currentHealth = 0;
    }

    public void OnGetFromPool(int maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }
} 