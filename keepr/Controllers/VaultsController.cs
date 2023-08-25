using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth0;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth0)
    {
        _vaultsService = vaultsService;
        _auth0 = auth0;
    }
}
