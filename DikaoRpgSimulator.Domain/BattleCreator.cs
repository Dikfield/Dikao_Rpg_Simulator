namespace DikaoRpgSimulator.Domain
{
    public class BattleCreator
    {
        public HeroEntity Hero { get; set; }
        public List<MonsterEntity> Monsters { get; set; }
        public BattleCreator(HeroEntity hero, List<MonsterEntity> monster)
        {
            Hero = hero;
            Monsters = monster;
        }

        public void HandleBattle()
        {

            Monsters.First().LostLife(Hero.Class, Hero.Attack, Monsters.First().Attack);

            if (Monsters.First().IsAlive())
            {
                while (Hero.IsAlive() && Monsters.Any())
                {
                    foreach (MonsterEntity monster in Monsters)
                    {
                        Hero.LostLife(Hero.Class, Hero.Attack, Monsters.First().Attack);
                    };

                    Monsters.First().LostLife(Hero.Class, Hero.Attack, Monsters.First().Attack);
                    if (!Monsters.First().IsAlive())
                    {
                        Hero.CheckAndUpXp(Monsters.First().GiveXp);
                        Hero.CheckAndUpLevel();
                        Hero.AttackAndDefenseCheck();
                        Monsters.Remove(Monsters.First());

                    }
                }
            }

            if (Hero.IsAlive())
            {
                for (int i = 0; i < Monsters.Count; i++)
                {
                    Hero.CheckAndUpXp(Monsters.First().GiveXp);
                    Hero.CheckAndUpLevel();
                    Hero.AttackAndDefenseCheck();
                    Monsters.Remove(Monsters.First());
                }


            }
            Hero.CheckAndUpLevel();
            Console.WriteLine("\nResult are\n");


        }
    }
}
