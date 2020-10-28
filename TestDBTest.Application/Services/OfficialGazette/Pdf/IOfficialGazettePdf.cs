using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDBTest.Services.OfficialGazette
{
    public interface IOfficialGazettePdf
    {
        IEnumerable<Entities.OfficialGazzete> GetGazzetes();
    }
}
