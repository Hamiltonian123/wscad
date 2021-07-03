using System.Collections.Generic;
using System.Threading.Tasks;
using wscad.BusinessLogic.Models;

namespace wscad.BusinessLogic.Services
{
    public interface IFileLoader
    {
        Task<List<Primitive>> LoadFileAsync(string filePath);
    }
}
