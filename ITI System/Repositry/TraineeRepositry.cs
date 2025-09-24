using ITI_System.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Repositry
{
    public class TraineeRepositry : ItraineeRepositry
    {
        ModelContext context;
        public TraineeRepositry(ModelContext _context)
        {
            context = _context;
        }
        public void Add(Trainee item)
        {
            context.Add(item);
        }

        public List<Trainee> GetAll()
        {
           return context.Trainees.ToList();
        }

        public Trainee GetById(int id)
        {
            return context.Trainees.FirstOrDefault(e => e.Id == id);
        }

        

        public void Remove(Trainee item)
        {
            context.Remove(item);
        }

        public void save()
        {
           context.SaveChanges();
        }

        public void Update(Trainee item)
        {
            context.Update(item);
        }

        public List<Trainee> TraineeDetails()
        {
            return context.Trainees.Include(d => d.department).ToList();


                                 
        }
    }
}
