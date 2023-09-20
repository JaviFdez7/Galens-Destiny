using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Upgrade : MonoBehaviour
{
    public interface IStatStrategy
    {
        void ApplyPermanentUpgrade(PlayerStats playerStats);
        void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds);
        int GetValue();
        string ResumeToString(PlayerStats playerStats, bool available);
    }

    public class StatStrategyFactory
    {
        public static IStatStrategy CreateVitalityStrategy(int vitality)
        {
            return new VitalityStatStrategy(vitality);
        }

        public static IStatStrategy CreateDamageStrategy(int damage)
        {
            return new DamageStatStrategy(damage);
        }

        public static IStatStrategy CreateAttackSpeedStrategy(int attackSpeed)
        {
            return new AttackSpeedStatStrategy(attackSpeed);
        }

        public static IStatStrategy CreateArmorStrategy(int armor)
        {
            return new ArmorStatStrategy(armor);
        }

        public static IStatStrategy CreateEnergyStrategy(int energy)
        {
            return new EnergyStatStrategy(energy);
        }

        public static IStatStrategy CreateWeightStrategy(int weight)
        {
            return new WeightStatStrategy(weight);
        }

        public static IStatStrategy CreateMovementSpeedStrategy(int movementSpeed)
        {
            return new MovementSpeedStatStrategy(movementSpeed);
        }

        // Add factory methods for other statistics here
    }


    public class VitalityStatStrategy : IStatStrategy
    {
        private int vitality;

        public VitalityStatStrategy(int vitality)
        {
            this.vitality = vitality;
        }

        public void ApplyPermanentUpgrade(PlayerStats playerStats)
        {
            playerStats.vitality += vitality;
        }

        public void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds)
        {
            playerStats.vitality += vitality;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                playerStats.vitality -= vitality;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return vitality;
        }

        public string ResumeToString(PlayerStats playerStats, bool available)
        {
            string res = "Vitality: +" + vitality;
            if(available)
            {
                return res +" (" + playerStats.vitality.ToString() + " -> " + (vitality + playerStats.vitality).ToString() + ")";
            } 
            return res;
        }
    }

    public class DamageStatStrategy : IStatStrategy
    {
        private int damage;

        public DamageStatStrategy(int damage)
        {
            this.damage = damage;
        }

        public void ApplyPermanentUpgrade(PlayerStats playerStats)
        {
            playerStats.damage += damage;
        }

        public void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds)
        {
            playerStats.damage += damage;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                playerStats.damage -= damage;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return damage;
        }

        public string ResumeToString(PlayerStats playerStats, bool available)
        {
            string res = "Damage: +" + damage;
            if(available)
            {
                return res +" (" + playerStats.damage.ToString() + " -> " + (damage + playerStats.damage).ToString() + ")";
            } 
            return res;
        }
    }

    public class AttackSpeedStatStrategy : IStatStrategy
    {
        private int attackSpeed;

        public AttackSpeedStatStrategy(int attackSpeed)
        {
            this.attackSpeed = attackSpeed;
        }

        public void ApplyPermanentUpgrade(PlayerStats playerStats)
        {
            playerStats.attackSpeed += attackSpeed;
        }

        public void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds)
        {
            playerStats.attackSpeed += attackSpeed;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                playerStats.attackSpeed -= attackSpeed;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return attackSpeed;
        }

        public string ResumeToString(PlayerStats playerStats, bool available)
        {
            string res = "Attack Speed: +" + attackSpeed;
            if(available)
            {
                return res +" (" + playerStats.attackSpeed.ToString() + " -> " + (attackSpeed + playerStats.attackSpeed).ToString() + ")";
            } 
            return res;
        }
    }

    public class ArmorStatStrategy : IStatStrategy
    {
        private int armor;

        public ArmorStatStrategy(int armor)
        {
            this.armor = armor;
        }

        public void ApplyPermanentUpgrade(PlayerStats playerStats)
        {
            playerStats.armor += armor;
        }

        public void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds)
        {
            playerStats.armor += armor;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                playerStats.armor -= armor;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return armor;
        }

        public string ResumeToString(PlayerStats playerStats, bool available)
        {
            string res = "Armor: +" + armor;
            if(available)
            {
                return res +" (" + playerStats.armor.ToString() + " -> " + (armor + playerStats.armor).ToString() + ")";
            } 
            return res;
        }
    }

    public class EnergyStatStrategy : IStatStrategy
    {
        private int energy;

        public EnergyStatStrategy(int energy)
        {
            this.energy = energy;
        }

        public void ApplyPermanentUpgrade(PlayerStats playerStats)
        {
            playerStats.energy += energy;
        }

        public void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds)
        {
            playerStats.energy += energy;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                playerStats.energy -= energy;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return energy;
        }

        public string ResumeToString(PlayerStats playerStats, bool available)
        {
            string res = "Energy: +" + energy;
            if(available)
            {
                return res +" (" + playerStats.energy.ToString() + " -> " + (energy + playerStats.energy).ToString() + ")";
            } 
            return res;
        }
    }

    public class WeightStatStrategy : IStatStrategy
    {
        private int weight;

        public WeightStatStrategy(int weight)
        {
            this.weight = weight;
        }

        public void ApplyPermanentUpgrade(PlayerStats playerStats)
        {
            playerStats.weight += weight;
        }

        public void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds)
        {
            playerStats.weight += weight;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                playerStats.weight -= weight;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return weight;
        }

        public string ResumeToString(PlayerStats playerStats, bool available)
        {
            string res = "Weight: +" + weight;
            if(available)
            {
                return res +" (" + playerStats.weight.ToString() + " -> " + (weight + playerStats.weight).ToString() + ")";
            } 
            return res;
        }
    }

    public class MovementSpeedStatStrategy : IStatStrategy
    {
        private int movementSpeed;

        public MovementSpeedStatStrategy(int movementSpeed)
        {
            this.movementSpeed = movementSpeed;
        }

        public void ApplyPermanentUpgrade(PlayerStats playerStats)
        {
            playerStats.movementSpeed += movementSpeed;
        }

        public void ApplyTemporaryUpgrade(PlayerStats playerStats, int seconds)
        {
            playerStats.movementSpeed += movementSpeed;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                playerStats.movementSpeed -= movementSpeed;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return movementSpeed;
        }

        public string ResumeToString(PlayerStats playerStats, bool available)
        {
            string res = "Movement Speed: +" + movementSpeed;
            if(available)
            {
                return res +" (" + playerStats.movementSpeed.ToString() + " -> " + (movementSpeed + playerStats.movementSpeed).ToString() + ")";
            } 
            return res;
        }
    }
    // Implement more strategies for other stats in the same way


}
