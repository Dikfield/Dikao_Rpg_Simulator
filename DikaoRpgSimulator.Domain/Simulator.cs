namespace DikaoRpgSimulator
{
    public class Simulator
    {
        public static int HeroIdSelection { get; protected set; }
        public static int BattleSimulationQty { get; protected set; }
        public static int Rounds { get; protected set; } = 0;
        public static bool MenuRepetition { get; protected set; } = true;
        public static string? MenuOption { get; protected set; }
        public static HeroEntity? CurrentHero { get; protected set; }

        public static DikaoRpgSimulator_DbContext Context = new DikaoRpgSimulator_DbContext();

        public Simulator()
        {

        }
        public Simulator(int heroId, int roundQty, DikaoRpgSimulator_DbContext context)
        {
            HeroIdSelection = heroId;
            Rounds = roundQty;
            Context = context;
        }
        public void SelectCurrentHero()
        {
            if (Context.HeroEntity != null)
            {
                if (HeroIdSelection != 0)
                    CurrentHero = Context.HeroEntity.Where(h => h.Id == HeroIdSelection).First();
            }
        }

        public void BattleEngine()
        {
            SelectCurrentHero();
            if (CurrentHero != null)
            {
                if (CurrentHero.Life > 0)
                {
                    BattleSimulationQty = Rounds;
                    StartBattle(BattleSimulationQty);

                }
            }



        }
        public void StartBattle(int NumberOfBattles)
        {
            if (CurrentHero != null)
            {
                while (NumberOfBattles > 0 && CurrentHero.Life > 0)
                {
                    var engine = new Engine(CurrentHero);
                    NumberOfBattles--;
                    HeroUpAfterBattle(CurrentHero.Id);

                }
            }


        }


        public void HeroUpAfterBattle(int heroId)
        {
            if (Context.HeroEntity != null)
            {
                Context.HeroEntity.Find(heroId);
                if (CurrentHero == null)
                    return;
                Context.HeroEntity.Update(CurrentHero);
                Context.SaveChanges();
            }
        }

    }

}
