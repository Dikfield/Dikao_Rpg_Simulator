namespace DikaoRpgSimulator.EndPoints.Heroes
{
    public class Post
    {
        public static string Route => "/heroes";
        public static async Task<IResult> Action(HeroesRequest heroesRequest,DikaoRpgSimulator_DbContext context)
        {
            if (context.HeroEntity == null)
                return Results.BadRequest("No database");

            var heroFactory = new HeroFactory(heroesRequest.Class, heroesRequest.Name);
            var hero = heroFactory.Create(heroesRequest.Class, heroesRequest.Name);

            await context.HeroEntity.AddAsync(hero);
            await context.SaveChangesAsync();
            return Results.Created($"/heroes {hero.Name}", hero.Name);



        }

    }
}
