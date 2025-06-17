using kolos2Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolos2Poprawa.Controllers;

[ApiController]
public class Controller : ControllerBase
{
    private readonly IDbService _dbService;

    public Controller(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    


}