using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


public class Character
{

    public string Name { get; set; }

    public int Health { get; set; }

    public int Gold { get; set; }

    public int Damage { get; set; }

    public SpecialAbility SpecialAbility { get; set; }

    public void UseSpecialAbility(Character target)
    {
        if (SpecialAbility != null)

            SpecialAbility.UseAbility(target);
        else

            Console.WriteLine($"{Name} nie ma przypisanej umiejętności specjalnej.");
    }

    public virtual void Attack(Character target)
    {

        Console.WriteLine($"{Name} atakuje {target.Name} za {Damage} obrażeń.");

        target.Health -= Damage;
    }
}