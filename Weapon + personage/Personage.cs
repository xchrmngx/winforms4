using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Weapon___personage
{
    public class Personage
    {

        public string Name;
        public int Level;
        public int Strength;
        public int Dexterity;
        public int Intellect;
        public Weapon CharacterWeapon;
        public string weaponType;

        public Personage()
        {
            Name = "Безымянный персонаж";
            Strength = 1;
            Dexterity = 1;
            Intellect = 10;
            Level = 1;
        }       

        public Personage(string name, int level, int strength, int dexterity, int intellect, string weaponType)
        {
            Name = name;
            Level = level;
            Strength = strength;
            Dexterity = dexterity;
            Intellect = intellect;
            this.weaponType = weaponType;
        }

        public int CalculatePower()// метод вычисления мощности
        {
            return ((Strength + Dexterity + Intellect) * Level) + (CharacterWeapon.Level * CharacterWeapon.Damage);
        }

        public string GetCharacterTitle()// расчёт и вывод звания персонажа
        {
            int power = CalculatePower();
            string weaponType = CharacterWeapon.TypeWeapon;

            if (weaponType == "Ствол")
            {
                if (power < 50) return "ствол";
                else if (power < 100) return "удачный ствол";
                else if (power < 200) return "хороший ствол";
                else if (power < 400) return "прекрасный ствол";
                else return "безжалостный ствол";
            }
            else if (weaponType == "Палка")
            {
                if (power < 50) return "Палка";
                else if (power < 100) return "палка-младший";
                else if (power < 200) return "палка-средний";
                else if (power < 400) return "палка-старший";
                else return "палчище";
            }
            else if (weaponType == "Копалка")
            {
                if (power < 50) return "копалыч";
                else if (power < 100) return "клевый копалыч";
                else if (power < 200) return "копалыч получше";
                else if (power < 400) return "копалыч покруче";
                else return "копалыч-копалыч";
            }
            else if (weaponType == "Камень")
            {
                if (power < 50) return "каменщик";
                else if (power < 100) return "каменщиче";
                else if (power < 200) return "старший камень";
                else if (power < 400) return "старый каменщик";
                else return "лучший старый каменщик";
            }

            return "Неизвестный персонаж";
        }
    }
}
