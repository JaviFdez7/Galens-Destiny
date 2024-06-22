using System.Collections.Generic;
using UnityEngine;
using static SkillsMenu;
public class ShootSkill : MonoBehaviour, IExecuteCommand
{
    public GameObject bulletPrefab;
    private Transform firePoint;

    public List<string> tagsToIgnore=new List<string>();

    public int fireDamage = 15;
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
        projectile.GetComponent<Bullet>().AddAllTagToIgnore(tagsToIgnore);
        projectile.GetComponent<Bullet>().SetDamage(fireDamage);
        CameraFollow.ScreenShake(0.2f, 0.2f);
    }
}

