using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace MyMobileProjec
{
    public class ExpenditureItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ExpenditureItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ExpenditureItem>().Wait();
        }

        public Task<List<ExpenditureItem>> GetItemsAsync()
        {
            return database.Table<ExpenditureItem>().ToListAsync();
        }

        public Task<List<ExpenditureItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<ExpenditureItem>("SELECT * FROM [ExpenditureItem] WHERE [Done] = 0");
        }

        public Task<ExpenditureItem> GetItemAsync(int id)
        {
            return database.Table<ExpenditureItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ExpenditureItem item)
        {

            if (item.ID != 0)
            {
                return database.UpdateAsync(item);

            }

            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveItemAsyncs(ExpenditureItem items)
        {
            
            if (items.Notes >= 0)
            {
                double total = 0;
                total = total + items.Notes;
                return database.UpdateAsync(items);
            }

            else
            {
                return database.InsertAsync(items);
            }

        }

        //-----------------
            public Task<int> DeleteItemAsync(ExpenditureItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
