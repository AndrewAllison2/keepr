using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;

    public KeepsService(KeepsRepository keepsRepository)
    {
        _keepsRepository = keepsRepository;
    }
}
