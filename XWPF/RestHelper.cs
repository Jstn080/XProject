using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XLibrary;
using XService.Models;

namespace XWPF
{
    static internal class RestHelper
    {
        static Uri uri = new Uri("https://localhost:7276/api/controller/");
        static JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private static HttpClient httpClient = new HttpClient();
        static RestHelper()
        {
            httpClient.BaseAddress = uri;
        }

        public static async Task<ObservableCollection<officers>> GetAllOfficers()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"Officers");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }
            string content = await response.Content.ReadAsStringAsync();
            ObservableCollection<officers> officers = JsonSerializer.Deserialize<ObservableCollection<officers>>(content,options);
            return officers;
        }
        public static async Task<ObservableCollection<trial>> GetTrials()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"Trial");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }
            string content = await response.Content.ReadAsStringAsync();
            ObservableCollection<trial> trials = JsonSerializer.Deserialize<ObservableCollection<trial>>(content,options);
            return trials;
        }
        public static async Task<ObservableCollection<criminal>> GetCriminals()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"Criminals");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }
            string content = await response.Content.ReadAsStringAsync();
            ObservableCollection<criminal> criminals = JsonSerializer.Deserialize<ObservableCollection<criminal>>(content, options);
            return criminals;
        }
        public static async Task<ObservableCollection<non_criminal>> GetNonCriminals()
        {
            HttpResponseMessage response = await httpClient.GetAsync($"Non Criminals");
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException();
            }
            string content = await response.Content.ReadAsStringAsync();
            ObservableCollection<non_criminal> noncriminals = JsonSerializer.Deserialize<ObservableCollection<non_criminal>>(content, options);
            return noncriminals;
        }
        public static async Task<bool> DeleteCriminal(int p_id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7276/api/controller/criminals/{p_id}");
            if(response.IsSuccessStatusCode == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static async Task<bool> DeleteTrial(int t_id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7276/api/controller/trial/{t_id}");
            if (response.IsSuccessStatusCode == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static async Task<bool> DeleteOfficer(int of_id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync($"https://localhost:7276/api/controller/officer/{of_id}");
            if (response.IsSuccessStatusCode == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static async Task<trial> AddTrial(trial trial)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(trial));
            HttpResponseMessage response = await httpClient.PostAsync($"https://localhost:7276/api/controller/trial", content);

            if(response.IsSuccessStatusCode == true)
            {
                trial newtrial = JsonSerializer.Deserialize<trial>(await response.Content.ReadAsStringAsync(), options);
                return newtrial;
            }
            else
            {
                return null;
            }
        }
        public static async Task<officers> AddOfficer(officers officers)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(officers));
            HttpResponseMessage response = await httpClient.PostAsync($"https://localhost:7276/api/controller/trial", content);

            if (response.IsSuccessStatusCode == true)
            {
                officers newofficer = JsonSerializer.Deserialize<officers>(await response.Content.ReadAsStringAsync(), options);
                return newofficer;
            }
            else
            {
                return null;
            }
        }
        public static async Task<criminal> AddCriminal(criminal criminal)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(criminal));
            HttpResponseMessage response = await httpClient.PostAsync($"https://localhost:7276/api/controller/trial", content);

            if (response.IsSuccessStatusCode == true)
            {
                criminal newcriminal = JsonSerializer.Deserialize<criminal>(await response.Content.ReadAsStringAsync(), options);
                return newcriminal;
            }
            else
            {
                return null;
            }
        }
        public static async Task<non_criminal> AddNoncriminal(non_criminal noncriminal)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(noncriminal));
            HttpResponseMessage response = await httpClient.PostAsync($"https://localhost:7276/api/controller/trial", content);

            if (response.IsSuccessStatusCode == true)
            {
                non_criminal newnoncriminal = JsonSerializer.Deserialize<non_criminal>(await response.Content.ReadAsStringAsync(), options);
                return newnoncriminal;
            }
            else
            {
                return null;
            }
        }

    }
}
