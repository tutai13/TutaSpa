using Microsoft.EntityFrameworkCore;
using TutaSpa_API.Models;
using TutaSpa_API.IRepository;
using TutaSpa_API.Data;

namespace TutaSpa_API.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDBContext _context;

        public TokenRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();
        }


        public async Task<RefreshToken?> GetFreshTokenByUserId(string UserID)
        {
            return await _context.RefreshTokens
                          .FirstOrDefaultAsync(t => t.UserId == UserID)
                          .ConfigureAwait(false);
        }

        public async Task<RefreshToken?> GetRefreshTokenByHash(string hashedToken)
        {
            return await _context.RefreshTokens
                          .FirstOrDefaultAsync(t => t.Token == hashedToken)
                          .ConfigureAwait(false);
        }

        public async Task UpdateAsync(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);
            await _context.SaveChangesAsync();
        }
    }
}
