using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



public class Enemy : Character
{
    public Enemy(string name)
    {

        Name = name;

        Health = new Random().Next(10, 30);

        Gold = new Random().Next(10, 30);

        Damage = new Random().Next(3, 10);

        SpecialAbility = new SpecialAbility("Poison Spit", 10);
    }

    public override void Attack(Character target)
    {

        base.Attack(target);
        target.Health -= Damage;
    }
}
