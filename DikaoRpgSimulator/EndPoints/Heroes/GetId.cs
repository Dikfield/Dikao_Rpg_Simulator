namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class GetId
    {
        public static string Route => "/heroes/{id}";


        public static IResult Action([FromRoute] int id, DikaoRpgSimulator_DbContext context)
        {
            if (context.HeroEntity == null)
                return Results.BadRequest("No database");

            var heroes = context.HeroEntity.ToList();
            var response = heroes.Where(q => q.Id == id).Select(c => new HeroesResponse (c.Name, c.Id, c.Class,
                c.Attack, c.Defense,c.Life, c.Level, c.Xp));

            return Results.Ok(response);
        }
    }
}
