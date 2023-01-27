using FRIDGamE.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace FRIDGamE.Models
{
    public class PublisherServiceEF : IPublisherService
    {
        private readonly IdentityContext _context;

        public PublisherServiceEF(IdentityContext context)
        {
            _context = context;
        }

        public IEnumerable<Publisher?> FindAll() => _context.Publishers.ToList();

        public Publisher? FindById(int? id)
        {
            return _context.Publishers.FirstOrDefault(x => x.Id == id);
        }

        public int Save(Publisher publisher)
        {
            try
            {
                var entityEntry = _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool Update(Publisher publisher)
        {
            try
            {
                var find = _context.Publishers.Find(publisher.Id);
                if (find is null)
                {
                    return false;
                }
                find.PublisherName = publisher.PublisherName;
                find.NIP = publisher.NIP;
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }
            var find = _context.Publishers.Find(id);
            if(find is null)
            {
                return false;
            }
            _context.Publishers.Remove(find);
            _context.SaveChanges();
            return true;
        }
    }
}
