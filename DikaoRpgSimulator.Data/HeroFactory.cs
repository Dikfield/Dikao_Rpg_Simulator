namespace DikaoRpgSimulator.Data
{
    public class HeroFactory
    {
        public HeroFactory(string? _class, string? name)
        {
            Create(_class, name);
        }
        public HeroEntity Create(string? _class, string? name)
        {
            var random = new Random();

            var hero = new HeroEntity();
            hero.Name = name;
            hero.Class = _class;
            hero.Dexterity = random.Next(2, 21);
            hero.Wisdom = random.Next(2, 21);
            hero.Strength = random.Next(2, 21);
            hero.Life = random.Next(40, 81);
            hero.Level = 1;
            hero.Xp = 0;
            hero.XpIncrement = 50;
            hero.MaxLife = hero.Life;
            hero.Defense = hero.Dexterity;
            switch (_class)
            {
                case "Archer":
                    hero.Attack = hero.Dexterity;
                    break;
                case "Mage":
                    hero.Attack = hero.Wisdom;
                    break;
                case "Warrior":
                    hero.Attack = hero.Strength;
                    break;
            };    
            return hero;
        }

    }
}
