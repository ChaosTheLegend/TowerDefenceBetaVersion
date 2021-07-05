using UnityEngine;

public class Castle : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);

            //TODO: You lose
        }
    }
}