using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keepr.Models;

public class Keep : RepoItem<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public string CreatorId { get; set; }
    public int Views { get; set; }
    public Profile Creator { get; set; }
}

public class VaultedKeep : Keep
{
    public int vaultKeepId { get; set; }
}
