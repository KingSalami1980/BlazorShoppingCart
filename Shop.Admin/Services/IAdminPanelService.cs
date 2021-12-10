using Shop.DataModels.CustomModels;
using System.Threading.Tasks;

namespace Shop.Admin.Services
{
    public interface IAdminPanelService
    {
        Task<ResponseModel> AdminLogin(LoginModel loginModel);
    }
}