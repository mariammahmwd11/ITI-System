using ITI_System.Models;

namespace ITI_System.Repositry
{
    public interface IcrsResultRepositry
    {
        public void Add(crsResult item);
        public void Remove(crsResult item);
        public void Update(crsResult item);
        public crsResult GetById(int id);
        public List<crsResult> GetAll();
        public void save();
        public crsResult getresultfortrainee_in_hisCourses(int traineeId, int crsId);
        public List<crsResult> GetResultsByTraineeId();
        public List<crsResult> getallresult(int id);

    }
}
