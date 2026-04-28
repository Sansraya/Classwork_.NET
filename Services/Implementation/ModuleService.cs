using Sem2.Services.Interface;
using Sem2.Modals.DTO.RequestDTO;
using Sem2.Data;
using Sem2.Data.Entities;

namespace Sem2.Services.Implementation
{
    public class ModuleService: IModuleService
    {

        private readonly ApplicationDbContext dbContext;
        public ModuleService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string> AddModuleAsync(ModuleDTO moduleDTOs)
        {

            if(moduleDTOs.CourseId != 0)
            {
                var course = await dbContext.Courses.FindAsync(moduleDTOs.CourseId);
                if (course == null)
                {
                    return "Course not found. Please provide a valid CourseId.";
                }
            }

            var module = new Module
            {
                Title = moduleDTOs.Title,
                Credit = moduleDTOs.ModuleCredits,
                CourseId= moduleDTOs.CourseId,
            };

            await dbContext.Modules.AddAsync(module);
            await dbContext.SaveChangesAsync();

            return "Module Added Successfully!";
        }
    }
}
