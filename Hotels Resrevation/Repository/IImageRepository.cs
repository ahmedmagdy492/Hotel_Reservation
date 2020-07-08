using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public interface IImageRepository
    {
        Task SaveImage(string path, string userId, bool isProfileImg = false);
        Task<IEnumerable<UserImage>> GetAllImages(string userId);
        Task<UserImage> GetImage(string userId);
        Task DeleteImage(int id);
        Task MakeAsProfile(int id, bool isProfileImage);
    }
}
