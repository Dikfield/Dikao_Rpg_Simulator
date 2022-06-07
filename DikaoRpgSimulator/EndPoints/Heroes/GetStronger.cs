namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class GetStronger
    {
        public static string Route => "/heroes";


        public static IResult Action([FromBody]HeroesRequest heroesRequest, DikaoRpgSimulator_DbContext context)
        {
            if (context.HeroEntity == null)
                return Results.BadRequest("No database");

            var heroes = context.HeroEntity.Where(c => c.Class == heroesRequest.Class).OrderByDescending(c => c.Level);
            var response = heroes.Select(c => new HeroesResponse (c.Name, c.Id, c.Class, 
                c.Attack, c.Defense, c.Life, c.Level, c.Xp)).FirstOrDefault();

            if (response == null)
                return Results.Ok("There is not this class");

            return Results.Ok(response);
        }
    }
}
