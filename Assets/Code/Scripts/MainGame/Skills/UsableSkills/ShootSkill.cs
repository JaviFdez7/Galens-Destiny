using UnityEngine;
using static SkillsMenu;
public class ShootSkill : MonoBehaviour, IExecuteCommand
{
    public GameObject bulletPrefab;
    private Transform firePoint;

    public float fireForce;
    public void Execute()
    {
        Skill activeSkill = SkillUtils.GetOneSkillFromAll(SkillEnum.Shoot);

        if (PlayerData.instance.currentEnergy
        - activeSkill.energyCost < 0)
            return;
        Energy.instance.SpendEnergy(2);
        Fire();
    }
    public void Fire()
    {
        if (firePoint == null)
            firePoint = GameObject.Find("FirePoint").transform;

        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * fireForce;
        CameraFollow.ScreenShake(0.2f, 0.2f);
    }
}