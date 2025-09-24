using ITI_System.Models;
using ITI_System.ViewModels;

namespace ITI_System.Repositry
{
    public interface IinstructorRepositry
    {
        public void Add(Instructor instructor);
        public void update(Instructor instructor);

        public void delete(int id);
        public Instructor GetById(int id);
        public List<Instructor> GetAll();
        public void save();
        public Instructor instDetails(int id); 
        public InstAndCrsList Edit(int id);
        



    }
}
