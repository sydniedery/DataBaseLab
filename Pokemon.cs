using QueryLab;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QueryLab
{
    public class Pokemon : IClassModel
    {
        public int Id { get; set; }
        public int DexNumber { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }


        public Pokemon()
        {
            Id = 0;
            DexNumber = 0;
            Name = "";
            Form = "";
            Type1 = "";
            Type2 = "";
            Total = 0;
            HP = 0;
            Attack = 0;
            Defense = 0;
            SpecialAttack = 0;
            SpecialDefense = 0;
            Speed = 0;
            Generation = 0;
        }//end constructor

        public Pokemon(int id, int dexNum, string name, string form, string type1, string type2, int total, int hp, int attack, int defence, int specialattack, int specialdefense, int speed, int generation)
        {
            Id = id;
            DexNumber = dexNum;
            Name = name;
            Form = form;
            Type1 = type1;
            Type2 = type2;
            Total = total;
            HP = hp;
            Attack = attack;
            Defense = defence;
            SpecialAttack = specialattack;
            SpecialDefense = specialdefense;
            Speed = speed;
            Generation = generation;

        }

        public override string ToString()
        {
            string str = "";
            str += "\nID: " + Id;
            str += "\nDexNumber: " + DexNumber;
            str += "\nName: " + Name;
            str += "\nForm: " + Form;
            str += "\nType1: " + Type1;
            str += "\nType2: " + Type2;
            str += "\nTotal: " + Total;
            str += "\nHP: " + HP;
            str += "\nAttack: " + Attack;
            str += "\nDefence: " + Defense;
            str += "\nSpecial Attack: " + SpecialAttack;
            str += "\nSpecial Defense: " + SpecialDefense;
            str += "\nSpeed: " + Speed;
            str += "\nGeneration: " + Generation;


            return str;
        }
    }//end class

}
