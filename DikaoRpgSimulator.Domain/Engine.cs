namespace DikaoRpgSimulator.Domain
{
    public class Engine
    {
        public HeroEntity Hero { get; set; }
        public Engine(HeroEntity hero)
        {
            Hero = hero;

            var battle = new BattleCreator(hero, MonsterGenerator());
            battle.HandleBattle();

        }
        public List<MonsterEntity> MonsterGenerator()
        {

            List<MonsterEntity> monsters = new List<MonsterEntity>();

            for (int i = 0; i < Hero.Level; i++)
            {
                var monsterFactory = new MonsterFactory();
                monsters.Add(monsterFactory.Create());
            }

            return monsters;

        }

    }
}
