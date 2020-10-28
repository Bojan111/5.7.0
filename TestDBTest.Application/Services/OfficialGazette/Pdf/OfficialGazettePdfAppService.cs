using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDBTest.Entities;
using TestDBTest.EntityFramework;

namespace TestDBTest.Services.OfficialGazette.Pdf
{
    public class OfficialGazettePdfAppService : IOfficialGazettePdf
    {
        private readonly TestDBTestDbContext db;

        public OfficialGazettePdfAppService(TestDBTestDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<OfficialGazzete> GetGazzetes()
        {
            return db.OfficialGazzete
                .Include(b => b.MedicalDeviceInfo)
                .Include(b => b.UseOfMedicalDevices)
                .Include(b => b.ManufacturerInfos);
        }
    }
}
