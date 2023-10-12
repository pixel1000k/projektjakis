using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


public class SpecialAbility
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public SpecialAbility(string name, int damage)
    {
        Name = name;

        Damage = damage;
    }

    public void UseAbility(Character target)
    {
        Console.WriteLine($"{target.Name} został zaatakowany za {Damage} obrażeń przez {Name}!");

        target.Health -= Damage;
    }
}
