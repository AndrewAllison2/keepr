using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Models;

public class VaultKeep : RepoItem<int>
{
    public string CreatorId { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }

}

