using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDoseOfMyLife.Model
{
    class EventRepository
    {
        private SQLiteAsyncConnection eventDatabase;
        private string databaseName = "events.db3";

        public EventRepository()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            eventDatabase = new SQLiteAsyncConnection(dbPath);
            eventDatabase.CreateTableAsync<EventInfo>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK).GetAwaiter().GetResult();
        }
        public async Task<ObservableCollection<EventInfo>> GetAllEvents()
        {
            var allEvents = await eventDatabase.Table<EventInfo>().ToListAsync();
            var allObservableEvents = new ObservableCollection<EventInfo>();
            foreach (var todo in allEvents)
            {
                allObservableEvents.Add(todo);
            }
            return allObservableEvents;
        }
        public async Task AddEvent(EventInfo todo)
        {
            await eventDatabase.InsertAsync(todo);
        }

        public async Task Update(EventInfo todo)
        {
            await eventDatabase.UpdateAsync(todo);
        }

        public async Task RemoveEvent(EventInfo todo)
        {
            await eventDatabase.DeleteAsync(todo);
        }


    }
}
