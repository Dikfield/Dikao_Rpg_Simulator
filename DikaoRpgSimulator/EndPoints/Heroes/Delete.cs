namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class Delete
    {
        public static string Route => "/heroes/{id}";


        public async static Task<IResult> Action([FromRoute] int id, DikaoRpgSimulator_DbContext context)
        {
            if (context.HeroEntity == null)
                return Results.BadRequest("No database");

            var heroes = context.HeroEntity.Where(h => h.Id == id).FirstOrDefault();
            if (heroes == null)
                return Results.BadRequest("Id is invalid");

            context.Remove(heroes);
            await context.SaveChangesAsync();
            return Results.Ok("Deleted");
        }
    }
}
