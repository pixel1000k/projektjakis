using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

public class HellBoss : Character
{
    public HellBoss()
    {
        Name = "Piekelny Demon";

        Health = 100; // Ustaw odpowiednie statystyki

        Damage = 20;

        SpecialAbility = new SpecialAbility("Ognista Furia", 25);
    }
}
