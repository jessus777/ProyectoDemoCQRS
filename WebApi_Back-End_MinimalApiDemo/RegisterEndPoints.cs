using WebApi_Back_End_MinimalApiDemo.EndPoints;

namespace WebApi_Back_End_MinimalApiDemo
{
    public static class RegisterEndPoints
    {

        public static WebApplication UseEndpoints(
         this WebApplication app)
        {

           CustomerEndPoints.CustomerEndpoints(app);

           //Users

          //Prodcuts

            //Orders

            return app;
        }
    }
    
}
