using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


public class Player : Character
{
    public Player(string name)
    {
        Name = name;

        Health = 50;

        Gold = 1234567;

        Damage = new Random().Next(6, 16);

        SpecialAbility = new SpecialAbility("Fireball", 15);
    }

    public override void Attack(Character target)
    {

        base.Attack(target);

    }
}
