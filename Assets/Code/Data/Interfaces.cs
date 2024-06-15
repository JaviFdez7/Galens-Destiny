using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage, Vector2 direction);
}

public interface IHealable
{
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
