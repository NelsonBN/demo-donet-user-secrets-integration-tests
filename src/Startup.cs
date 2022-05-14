namespace Demo;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
        => _configuration = configuration;


    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<DemoConfig>(_configuration);

        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseEndpoints(endpoints
            => endpoints.MapControllers() // Mapping all controller
        );
    }
}
