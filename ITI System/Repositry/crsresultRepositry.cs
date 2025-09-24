using ITI_System.Models;
using ITI_System.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ITI_System.Repositry
{
    public class crsresultRepositry : IcrsResultRepositry
    {
        ModelContext context;
        public crsresultRepositry(ModelContext context)
        {
            this.context = context;
        }
       public void Add(crsResult item)
        {
            context.Add(item);
        }

       public List<crsResult> GetAll()
        {
           return context.crsResults.ToList();
        }

       public crsResult GetById(int id)
        {
          return  context.crsResults.FirstOrDefault(e => e.Id == id);
        }

       public List< crsResult> getresultbytraineeid(int id)
        {
            throw new NotImplementedException();
        }

       public void Remove(crsResult item)
        {
           context.Remove(item);
        }

      public  void save()
        {
            context.SaveChanges();
        }

      public  void  Update(crsResult item)
        {
           context.Update(item);
        }

        public crsResult getresultfortrainee_in_hisCourses(int traineeId, int crsId)
        {
             
           return context.crsResults
                .Include(r => r.course)
                .FirstOrDefault(r => r.traineeId == traineeId && r.crsId == crsId);
        }

        public List<crsResult> GetResultsByTraineeId()
        {
            return context.crsResults.Include(c => c.course).ToList();
        }

        public List<crsResult> getallresult(int id)
        {
           return context.crsResults
                .Include(r => r.course)
                .Where(r => r.traineeId == id)
                .ToList();
        }
    }
}
