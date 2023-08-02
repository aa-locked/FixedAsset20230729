using FixedAsset.Model.Domain.MaterialGroup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.DataAccess.Data
{
    public class FixedAssetDBContext :DbContext 
    {
        public FixedAssetDBContext(DbContextOptions<FixedAssetDBContext> dbContextOptions):base(dbContextOptions) 
        {

        }

        public DbSet<TFAMtrlGrp> tFAMtrlGrp { get; set; }
        public DbSet<TFAMtrlSubGrp> tFAMtrlSubGrp { get;set; }
    }
}
