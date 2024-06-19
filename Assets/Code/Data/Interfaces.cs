using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage, Vector2 direction);

    void Die();

    void Heal(int amount);
}

public interface IInteractable
{
    void Interact();
}

public interface IUnlockable
{
    void Unlock();
}
