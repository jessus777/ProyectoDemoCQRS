

namespace WebApi_Back_End_MinimalApiDemo
{
    public static class WebApplicationHelper
    {
        public static WebApplication CreateWebApplication(
           this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //CorsConfigure
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            builder.Services.AddApplicationLayer();
            builder.Services.AddInfrastructurePersistenceLayer(builder.Configuration);

            return builder.Build();
        }

        public static WebApplication ConfigureWebApplication(
           this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();
            app.UseCors("Open");
            app.UseEndpoints();
            
            return app;
        }
    }
}
