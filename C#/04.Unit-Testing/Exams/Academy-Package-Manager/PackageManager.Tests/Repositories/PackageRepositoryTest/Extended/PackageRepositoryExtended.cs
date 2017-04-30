using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Repositories.PackageRepositoryTest.Extended
{
    public class PackageRepositoryExtended : PackageRepository
    {
        public PackageRepositoryExtended(ILogger logger, ICollection<IPackage> packages = null) 
            : base(logger, packages)
        {
        }

        public override bool Update(IPackage package)
        {
            throw new MyCustomExeption_Shtoto_Si_MoGa_Update_Da_Se_Znae();
        }
    }
}
