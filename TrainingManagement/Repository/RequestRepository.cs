using TrainingManagement.Context;
using TrainingManagement.Models;

namespace TrainingManagement.Repository
{
    public class RequestRepository:InterfaceRequest
    {
        TrainingDbContext _db;
        public RequestRepository(TrainingDbContext db)
        {
            _db = db;
        }
        public List<Request> GetRequest()
        {
            return _db.Requests.ToList();
        }

        public Request GetRequestById(int id)
        {
            return _db.Requests.FirstOrDefault(x => x.RequestId == id);
        }


        public Request Create(Request request)
        {
            _db.Requests.Add(request);
            _db.SaveChanges();
            return request;
        }


    }
}
