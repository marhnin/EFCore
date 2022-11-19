namespace SchoolAPI.DAL
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
