namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class GetAll
    {
        public static string Route => "/heroes";


        public static IResult Action(DikaoRpgSimulator_DbContext context)
        {
            if (context.HeroEntity == null)
                return Results.BadRequest("No database");

            var heroes = context.HeroEntity.ToList();
            var response = heroes.Select(c => new HeroesResponse (c.Name, c.Id, c.Class,
                c.Xp, c.Level, c.Life, c.Attack, c.Defense));

            return Results.Ok(response);
        }
    }
}
