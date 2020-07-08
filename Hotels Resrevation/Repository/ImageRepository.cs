using Hotels_Resrevation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels_Resrevation.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext db;

        public ImageRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task DeleteImage(int id)
        {
            var img = await db.Images.FirstOrDefaultAsync(i => i.Id == id);

            if (img != null)
            {
                db.Images.Remove(img);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserImage>> GetAllImages(string userId)
        {
            return await db.Images.Where(i => i.UserId == userId).ToListAsync();
        }

        public async Task<UserImage> GetImage(string userId)
        {
            return await db.Images.FirstAsync(i => i.UserId == userId);
        }

        public async Task SaveImage(string path, string userId, bool isProfileImg = false)
        {
            var img = new UserImage
            {
                IsProfileImg = isProfileImg,
                Title = path,
                UserId = userId
            };
            db.Images.Add(img);
            await db.SaveChangesAsync();
        }

        public async Task MakeAsProfile(int id, bool isProfileImage)
        {
            var img = await db.Images.FirstOrDefaultAsync(i => i.Id == id);
            img.IsProfileImg = isProfileImage;
            db.Entry(img).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
