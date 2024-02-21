using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weapon___personage
{
    public class Weapon
    {
        public string Name;
        public int Level;
        public int Damage;
        public string TypeWeapon;

        public Weapon()
        {
            Name = "Безымянный камень";
            Level = 1;
            Damage = 10;
            TypeWeapon = "камень";
        }

        public Weapon(string Name, int Level, int Damage, string TypeWeapon)
        {
            this.Name = Name;
            this.Level = Level;
            this.Damage = Damage;
            this.TypeWeapon = TypeWeapon;
        }

        public static Weapon operator +(Weapon weapon1, Weapon weapon2)
        {
            return new Weapon(weapon1.Name + "+", ++weapon1.Level, weapon1.Damage *2, weapon1.TypeWeapon); //улучшение оружия
        }
    }
}

