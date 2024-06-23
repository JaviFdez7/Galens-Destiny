using UnityEngine;

public interface IDamageable
{
    // event when the health of the object changes, returns the current health
    event System.Action<int> OnHealthChanged;
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

public interface IBullet{
    void SetTarget(Vector2 target);
}
