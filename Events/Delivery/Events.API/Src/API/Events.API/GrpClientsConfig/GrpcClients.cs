using Events.Application.Protos;

namespace _4EPlatform_Events.GrpClientsConfig
{

    public static class GrpcClients
    {
        #region UserManagement
        public static void AddUserManagementGrpcClients(
            this IServiceCollection services,
            string UserManagmentUrl)
        {
            services.AddGrpcServiceClient<PermissionGroupingService.PermissionGroupingServiceClient>(UserManagmentUrl);
            services.AddGrpcServiceClient<UserProtoService.UserProtoServiceClient>(UserManagmentUrl);
        }
        #endregion

    }
}
