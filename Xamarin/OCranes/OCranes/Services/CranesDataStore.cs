using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OCranes.Models;
using Plugin.CloudFirestore;

namespace OCranes.Services
{
    public class CranesDataStore: IDataStore<Crane>
    {
        public CranesDataStore()
        {
        }

        public async Task<bool> AddItemAsync(Crane item)
        {
            try
            {
                await CrossCloudFirestore.Current.Instance
                                .GetCollection("cranes")
                                .AddDocumentAsync(item);
            }
            catch(Exception e)
            {
                throw new Exception("Exception in add crane", e);
            }

            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                await CrossCloudFirestore.Current.Instance
                             .GetCollection("cranes")
                             .GetDocument(id)
                             .DeleteDocumentAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Exception in delete crane.", e);
            }

            return true;
        }

        public async Task<Crane> GetItemAsync(string id)
        {
            IDocumentSnapshot document;
            try
            {
                document = await CrossCloudFirestore.Current.Instance
                    .GetCollection("cranes")
                    .GetDocument(id)
                    .GetDocumentAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Exception in get crane.", e);
            }

            var crane = document.ToObject<Crane>();
            return crane;
        }

        public async Task<IEnumerable<Crane>> GetItemsAsync(bool forceRefresh = false)
        {
            IQuerySnapshot group;
            try
            {
                group = await CrossCloudFirestore.Current.Instance
                .GetCollection("cranes")
                .GetDocumentsAsync();
            }
            catch(Exception e)
            {
                throw new Exception("Exception in get cranes.", e);
            }

            var cranes = group.ToObjects<Crane>();
            return cranes;
        }

        public async Task<bool> UpdateItemAsync(Crane item)
        {
            try
            {
                await CrossCloudFirestore.Current.Instance
                             .GetCollection("cranes")
                             .GetDocument(item.Id)
                             .UpdateDataAsync(item);
            }
            catch(Exception e)
            {
                throw new Exception("Exception in update crane.", e);
            }

            return true;
        }
    }
}
