using UnityEngine;
using static SkillsMenu;

public class EmotionalInsightSkill : MonoBehaviour, ISkill
{
    public GameObject bulletPrefab;
    private Transform firePoint;
    public float fireForce;
    public void Activate()
    {
        Skill activeSkill = null;

        foreach (Skill skill in SkillData.instance.activeSkills)
            if (skill != null && skill.name == "Emotional Insight")
            {
                activeSkill = skill;
                break;
            }
                

        if (PlayerData.instance.currentEnergy - activeSkill.energyCost < 0)
            return;

        Energy.instance.SpendEnergy(2);
        Fire();
    }

    public void Fire()
    {
        if (firePoint == null)
            firePoint = GameObject.Find("FirePoint").transform;
            
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
