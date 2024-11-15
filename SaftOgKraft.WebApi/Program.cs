using DAL.DAO;

namespace SaftOgKraft.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            const string connectionString = "Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-S231_10503093;User ID=DMA-CSD-S231_10503093;Password=Password1!;TrustServerCertificate=True;";
            builder.Services.AddSingleton<IProductDAO>((_) => new ProductDAO(connectionString));
            //builder.Services.AddSingleton<INogetAndetDAO>((_) => new NogetAndetDAO(connectionString));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
