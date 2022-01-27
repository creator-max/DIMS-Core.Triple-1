using Microsoft.AspNetCore.Builder;

namespace DIMS_Core.BusinessLayer.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomEndpoints(this IApplicationBuilder builder)
        {
            return builder.UseEndpoints(endpoints =>
                                        {
                                            endpoints.MapControllerRoute("default",
                                                                         "{controller=Home}/{action=Index}/{id?}");
                                        });
        }
    }
}