using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class AcadProgramSQLRepository : IAcadProgramRepository
    {
        private readonly EscolarisContext db;
        public AcadProgramSQLRepository(EscolarisContext db)
        {
            this.db = db;
        }

        public void AddAcadProgram(AcadProgram acadprogram)
        {
            db.AcadPrograms.Add(acadprogram);
            db.SaveChanges();
        }

        public void DeleteAcadProgram(int programId)
        {
            var program = db.AcadPrograms.Find(programId);
            if (program == null) return;

            db.AcadPrograms.Remove(program);
            db.SaveChanges();
        }

        public AcadProgram? GetAcadProgramById(int programId, bool loadCategory = false)
        {
            if (loadCategory)
                return db.AcadPrograms
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.ProgramId == programId);
            else
                return db.AcadPrograms
                    .FirstOrDefault(x => x.ProgramId == programId);
        }

        public IEnumerable<AcadProgram> GetAcadPrograms(bool loadCategory = false)
        {
            if (loadCategory)
                return db.AcadPrograms.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList();
            else
                return db.AcadPrograms.OrderBy(x => x.Category).ToList();

        }

        public IEnumerable<AcadProgram> GetAcadProgramByCategoryId(int categoryId)
        {
            return db.AcadPrograms.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateAcadProgram(int programId, AcadProgram acadProgram)
        {
            if (programId != acadProgram.ProgramId) return;

            var programToUpdate = db.AcadPrograms.Find(programId);

            if (programToUpdate != null)
            {
                programToUpdate.Name = acadProgram.Name;
                programToUpdate.Quantity = acadProgram.Quantity;
                programToUpdate.Price = acadProgram.Price;
                programToUpdate.CategoryId = acadProgram.CategoryId;

                db.SaveChanges();
            }
        }
    }
}
