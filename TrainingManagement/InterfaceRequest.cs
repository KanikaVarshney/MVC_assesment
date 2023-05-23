using TrainingManagement.Models;

namespace TrainingManagement
{
    public interface InterfaceRequest
    {
        List<Request> GetRequest();

        Request Create(Request request);
        Request GetRequestById(int id);
    }
}
