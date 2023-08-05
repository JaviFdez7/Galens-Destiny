using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Config", menuName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    public float moveSpeed = 3f;
    public float attackRange = 5f;
    // Agrega otras configuraciones según sea necesario
}
