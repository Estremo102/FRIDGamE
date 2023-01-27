namespace FRIDGamE.Models
{
    public interface IPublisherService
    {
        public IEnumerable<Publisher?> FindAll();

        public Publisher? FindById(int? id);

        public int Save(Publisher publisher);

        public bool Update(Publisher publisher);

        public bool Delete(int? id);
    }
}