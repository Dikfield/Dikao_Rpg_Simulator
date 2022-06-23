namespace DikaoRpgSimulator.EndPoints.Battles
{
    public class GetLast
    {
        public static string Route => "/Lastbattle";


        public static IResult Action(DikaoRpgSimulator_DbContext context)
        {
            if (context.BattleData == null)
                return Results.BadRequest("No data");

            var battles = context.BattleData.OrderByDescending(c => c.Id);
            var response = battles.Select(c => new BattlesResponse (c.Id, c.HeroEntityId,
                c.MonsterQty, c.Hero)).FirstOrDefault();


            return Results.Ok(response);
        }
    }
}
