using TrainingManagement.Models;

namespace TrainingManagement
{
    public interface InterfaceBatch
    {
        List<BatchViewModel> GetBatches();
        Batch Create(Batch batch);
        int Edit(int id, Batch batch);
        Batch GetBatchById(int id);
        //int Edit(int id, Course course);
        //int Delete(int id);
    }
}
