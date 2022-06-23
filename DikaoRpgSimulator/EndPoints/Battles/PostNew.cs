namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class PostNew
    {
        public static string Route => "/battles";

        public async static Task<IResult> Action(BattlesRequest battlesRequest, DikaoRpgSimulator_DbContext context)
        {
            if (context.HeroEntity == null)
                return Results.BadRequest("No database");
            var hero = context.HeroEntity.FirstOrDefault(f => f.Id == battlesRequest.HeroId);

            if (hero == null)
                return Results.BadRequest("Hero Id doesnt exist");


            else if (CheckRoundQty(battlesRequest))
                return Results.BadRequest("Invalid quantity of rounds");

            else if (hero.Life > 0)
            {
                var battle = new Simulator(battlesRequest.HeroId, battlesRequest.RoundQty, context);
                battle.BattleEngine();
                var battleData = new BattleData
                {
                    HeroEntityId = battlesRequest.HeroId,
                    Rounds = battlesRequest.RoundQty,
                    Hero = hero
                };
                await context.AddAsync(battleData);
                await context.SaveChangesAsync();
                return Results.Created($"/battles Hero {battleData.Hero.Name}", battleData.Hero.Name);
            }
            return Results.BadRequest("The hero is dead");
        }
        private static bool CheckRoundQty(BattlesRequest battlesRequest) =>
            battlesRequest.RoundQty > 100 || battlesRequest.RoundQty <= 0;
            
        
    }
}
