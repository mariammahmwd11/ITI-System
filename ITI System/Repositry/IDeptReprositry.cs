using ITI_System.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_System.Repositry
{
    public interface IDeptReprositry
    {
        public void Add(Department department);


        public void update(Department department);



        public void delete(int id);



        public Department GetById(int id);



        public List<Department> GetAll();



        public void save();
        public List<SelectListItem> GetAllDeptsWithNameandId();


    }
}
