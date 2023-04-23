namespace VasilekCerozhka.Data
{
    public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 1,
                FirstName = "Anessens",
                LastName = "Anessens",
                MiddleName = "Anessens",
                Email = "avgorlov899@gmail.com",
                BirthDate = new DateTime(1991, 12, 09),
                SecurityStamp = Guid.NewGuid().ToString(),

            });
        }
    }
}
