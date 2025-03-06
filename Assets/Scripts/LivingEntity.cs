using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    
    public float startingHealth;
    protected float health;


    protected virtual void Start()
    {
        health = startingHealth;
    }

    
    public virtual void TakeHit(float damage)
    {
        health -= damage;
    }
    
}
