using Microsoft.EntityFrameworkCore;
using khoahoconline.Data.Entities;

namespace khoahoconline.Data.Repositories.Impl
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(CourseOnlDbContext context) :base(context)
        {
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            var refreshToken = await _dbSet.Include(refreshToken => refreshToken.NguoiDung).FirstOrDefaultAsync(refreshToken => refreshToken.Token == token);
            return refreshToken;
        }
    }
}
