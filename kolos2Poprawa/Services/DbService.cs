using kolos2Poprawa.Database;

namespace kolos2Poprawa.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
}