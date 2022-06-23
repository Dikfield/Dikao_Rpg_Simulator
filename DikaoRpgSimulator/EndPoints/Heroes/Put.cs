namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class Put
    {
        public static string Route => "/heroes/{id}";

        public async static Task<IResult> Action([FromRoute] int id, HeroesRequest heroesRequest,DikaoRpgSimulator_DbContext context)
        {
            if (context.HeroEntity == null)
                return Results.BadRequest("No database");

            var heroes = context.HeroEntity.Where(h => h.Id == id).FirstOrDefault();

            if (heroes == null)
                return Results.NotFound();

            heroes.Name = heroesRequest.Name;

            await context.SaveChangesAsync();

            return Results.Ok();

        }
    }
}
