using AdminApp.Models;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public class StateContainer
    {
        private string savedString;
        private string _lang = "en";

        public User user = null;
        public static string basePath = "";

        public string lang
        {

            get
            {
                return _lang;
            }

            set
            {

                _lang = value ?? "EN";
                NotifyStateChanged();

            }
        }

        public List<BreadCrumbItem> BreadCrumbItems { get; set; } =  new List<BreadCrumbItem>
        {
             new BreadCrumbItem{ Link="", Text="Home"}
        };


        public int currentCount;
        private Dictionary<string, string> _langItems = new Dictionary<string, string>();
        public Dictionary<string, string> LangItems
        {

            get
            {
                return _langItems;
            }

            set
            {

                _langItems = value;
                NotifyStateChanged();
            }
        }

        public string Localized(string key)
        {
            if (key != null && LangItems != null && LangItems.ContainsKey(key))
            {
                return LangItems[key];
            }

            return "";

        }

        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        public Dictionary<string, string> Langs { get; set; } = new Dictionary<string, string>
        {
            {"EN","English" },
            {"TR","Turkish" }
        };

        private List<MenuItem> menuItems = new List<MenuItem>();
        public List<MenuItem> MenuItems
        {

            get
            {
                return menuItems;
            }

            set
            {

                menuItems = value ?? new List<MenuItem>();
                NotifyStateChanged();
            }
        }

        Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }
        Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }

        HttpClient Http;

        public StateContainer(ISessionStorageService _sessionStorage, ILocalStorageService _localStorage, HttpClient http)
        {
            sessionStorage = _sessionStorage;
            localStorage = _localStorage;
            Http = http;

            timer.Elapsed += (sender, eventArgs) => OnTimerCallback();
            timer.Start();

            Task.Run(async () =>
            {
                var selectedLang = ((await localStorage.GetItemAsync<string>("lang")) ?? lang);
                lang = selectedLang;
            });

        }

        public string Property
        {
            get => savedString;
            set
            {
                savedString = value;
                NotifyStateChanged();
            }
        }

        private void OnTimerCallback()
        {
            currentCount++;
            NotifyTimerChanged();
        }

        public void Dispose() => timer.Dispose();

        public event Action OnChange;
        public event Action OnTimerChange;


        private void NotifyStateChanged() => OnChange?.Invoke();
        private void NotifyTimerChanged() => OnTimerChange?.Invoke();


    }
}
