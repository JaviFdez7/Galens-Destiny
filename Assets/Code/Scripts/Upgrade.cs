using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Upgrade : MonoBehaviour
{
    public interface IStatStrategy
    {
        void ApplyPermanentUpgrade();
        void ApplyTemporaryUpgrade(int seconds);
        int GetValue();
        string ResumeToString(bool available);
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

        public void ApplyPermanentUpgrade()
        {
            PlayerData.instance.vitality += vitality;
        }

        public void ApplyTemporaryUpgrade(int seconds)
        {
            PlayerData.instance.vitality += vitality;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                PlayerData.instance.vitality -= vitality;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return vitality;
        }

        public string ResumeToString(bool available)
        {
            string res = "Vitality: +" + vitality;
            if(available)
            {
                return res +" (" + PlayerData.instance.vitality.ToString() + " -> " + (vitality + PlayerData.instance.vitality).ToString() + ")";
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

        public void ApplyPermanentUpgrade()
        {
            PlayerData.instance.damage += damage;
        }

        public void ApplyTemporaryUpgrade(int seconds)
        {
            PlayerData.instance.damage += damage;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                PlayerData.instance.damage -= damage;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return damage;
        }

        public string ResumeToString(bool available)
        {
            string res = "Damage: +" + damage;
            if(available)
            {
                return res +" (" + PlayerData.instance.damage.ToString() + " -> " + (damage + PlayerData.instance.damage).ToString() + ")";
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

        public void ApplyPermanentUpgrade()
        {
            PlayerData.instance.attackSpeed += attackSpeed;
        }

        public void ApplyTemporaryUpgrade(int seconds)
        {
            PlayerData.instance.attackSpeed += attackSpeed;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                PlayerData.instance.attackSpeed -= attackSpeed;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return attackSpeed;
        }

        public string ResumeToString(bool available)
        {
            string res = "Attack Speed: +" + attackSpeed;
            if(available)
            {
                return res +" (" + PlayerData.instance.attackSpeed.ToString() + " -> " + (attackSpeed + PlayerData.instance.attackSpeed).ToString() + ")";
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

        public void ApplyPermanentUpgrade()
        {
            PlayerData.instance.armor += armor;
        }

        public void ApplyTemporaryUpgrade(int seconds)
        {
            PlayerData.instance.armor += armor;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                PlayerData.instance.armor -= armor;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return armor;
        }

        public string ResumeToString(bool available)
        {
            string res = "Armor: +" + armor;
            if(available)
            {
                return res +" (" + PlayerData.instance.armor.ToString() + " -> " + (armor + PlayerData.instance.armor).ToString() + ")";
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

        public void ApplyPermanentUpgrade()
        {
            PlayerData.instance.energy += energy;
        }

        public void ApplyTemporaryUpgrade(int seconds)
        {
            PlayerData.instance.energy += energy;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                PlayerData.instance.energy -= energy;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return energy;
        }

        public string ResumeToString(bool available)
        {
            string res = "Energy: +" + energy;
            if(available)
            {
                return res +" (" + PlayerData.instance.energy.ToString() + " -> " + (energy + PlayerData.instance.energy).ToString() + ")";
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

        public void ApplyPermanentUpgrade()
        {
            PlayerData.instance.weight += weight;
        }

        public void ApplyTemporaryUpgrade(int seconds)
        {
            PlayerData.instance.weight += weight;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                PlayerData.instance.weight -= weight;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return weight;
        }

        public string ResumeToString(bool available)
        {
            string res = "Weight: +" + weight;
            if(available)
            {
                return res +" (" + PlayerData.instance.weight.ToString() + " -> " + (weight + PlayerData.instance.weight).ToString() + ")";
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

        public void ApplyPermanentUpgrade()
        {
            PlayerData.instance.movementSpeed += movementSpeed;
        }

        public void ApplyTemporaryUpgrade(int seconds)
        {
            PlayerData.instance.movementSpeed += movementSpeed;

            Timer timer = new Timer(seconds * 1000);
            timer.Elapsed += (sender, e) => // when the timer reaches 0 it is executed timer.Elapsed
            {
                PlayerData.instance.movementSpeed -= movementSpeed;

                timer.Stop();
                timer.Dispose();
            };

            timer.Start();
        }

        public int GetValue()
        {
            return movementSpeed;
        }

        public string ResumeToString(bool available)
        {
            string res = "Movement Speed: +" + movementSpeed;
            if(available)
            {
                return res +" (" + PlayerData.instance.movementSpeed.ToString() + " -> " + (movementSpeed + PlayerData.instance.movementSpeed).ToString() + ")";
            } 
            return res;
        }
    }
    // Implement more strategies for other stats in the same way


}
