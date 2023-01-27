using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRIDGamE;
using FRIDGamE.Models;

namespace FRIDGamE_test
{
    public class PublisherServiceTest : IPublisherService
    {
        private readonly Dictionary<int, Publisher> Publishers;
        public PublisherServiceTest()
        {
            Publishers = new Dictionary<int, Publisher>();
            Publishers.Add(1, new Publisher() { Id = 1, PublisherName = "ZSHT", NIP = "7361066403" });
            Publishers.Add(2, new Publisher() { Id = 2, PublisherName = "Yacoper INC", NIP = "3503493043" });
            Publishers.Add(3, new Publisher() { Id = 3, PublisherName = "Take-Two Interactive", NIP = "2095394934" });
            Publishers.Add(4, new Publisher() { Id = 4, PublisherName = "CDPR", NIP = "2450923585" });
        }

        public bool Delete(int? id) => (id is null) ? false : Publishers.Remove((int)id);

        public IEnumerable<Publisher?> FindAll()
        {
            foreach (var item in Publishers)
            {
                yield return item.Value;
            }
        }

        public Publisher? FindById(int? id)
        {
            if(id == null || !Publishers.ContainsKey((int)id))
            {
                return null;
            }
            return Publishers[(int)id];
        }

        public int Save(Publisher publisher)
        {
            Publishers.Add(publisher.Id, publisher);
            return publisher.Id;
        }

        public bool Update(Publisher publisher)
        {
            if(!Publishers.ContainsKey(publisher.Id))
            {
                return false;
            }
            Publisher find = Publishers[publisher.Id];
            if(find is null)
            {
                return false;
            }
            find.PublisherName = publisher.PublisherName;
            find.NIP = publisher.NIP;
            find.games = publisher.games;
            return true;
        }
    }
}