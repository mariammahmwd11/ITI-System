using ITI_System.Models;

namespace ITI_System.Repositry
{
    public interface ItraineeRepositry
    {
        public void Add(Trainee item);
        public void Remove(Trainee item);
        public void Update(Trainee item);
       
        public Trainee GetById(int id);

        public List<Trainee> GetAll();
        public void save();

        public List<Trainee> TraineeDetails();

    }
}
