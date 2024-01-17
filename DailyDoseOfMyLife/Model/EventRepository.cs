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
        private static bool isLoggedIn = false;
        public static string username="";
        public EventRepository()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            eventDatabase = new SQLiteAsyncConnection(dbPath);
            eventDatabase.CreateTableAsync<EventInfo>(CreateFlags.AllImplicit | CreateFlags.AutoIncPK).GetAwaiter().GetResult();
        }
        public async Task<List<EventInfo>> GetAllEvents()
        {
            var allEvents = await eventDatabase.Table<EventInfo>().ToListAsync();
            return allEvents;
        }
        public async Task AddEvent(EventInfo todo)
        {
            await eventDatabase.InsertAsync(todo);
        }
        
        public async Task<List<EventInfo>> TodaysTodos()
        {
            var allevents = await eventDatabase.Table<EventInfo>().ToListAsync();
            List<EventInfo> todayTodos = new List<EventInfo>();
            foreach (EventInfo oneEvent in allevents)
            {
                if (oneEvent.isChecked == false && oneEvent.Date==DateTime.Today && oneEvent.userName == username)
                {
                    todayTodos.Add(oneEvent);
                }
            }
            return todayTodos;
        }

        public async Task Update(EventInfo todo)
        {
            await eventDatabase.UpdateAsync(todo);
        }

        public async Task RemoveEvent(EventInfo todo)
        {
            await eventDatabase.DeleteAsync(todo);
        }

        public async Task ChangeIsChecked(EventInfo todo)
        {
            todo.isChecked= true;
            await eventDatabase.UpdateAsync(todo);
        }
        public void LoggingIn()
        {
            if (isLoggedIn == false)
            
             Shell.Current.GoToAsync("LoginPage");
            

        }
        public void LoggedIn()
        {
            isLoggedIn = true;
        }
        public void LogOut()
        {
            isLoggedIn = false;
            SetUsername("");
        }

        public void SetUsername(string newUsername)
        {
            username = newUsername;
        }

        public string GetUsername() { return username; }
    }
}
