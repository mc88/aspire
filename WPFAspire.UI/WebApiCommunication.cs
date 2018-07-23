using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WPFAspire.BusinessInterfaces.Models;

namespace WPFAspire.UI
{
    public class WebApiCommunication
    {
        private HttpClient client = new HttpClient();

        public WebApiCommunication()
        {
            client.BaseAddress = new Uri("http://mchrobak-nb1/WPFAspire.WebApi/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task AddContact(AddContactModel contact)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Contact/AddContact", contact);
            response.EnsureSuccessStatusCode();
        }

        public async void EditContact(EditContactModel contact)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Contact/EditContact", contact);
            response.EnsureSuccessStatusCode();
        }

        public async Task<ContactViewModel> GetContact(int id)
        {
            ContactViewModel contact = null;
            HttpResponseMessage response = await client.GetAsync("api/Contact/GetContact/" + id);
            if (response.IsSuccessStatusCode)
            {
                contact = await response.Content.ReadAsAsync<ContactViewModel>();
            }
            return contact;
        }

        public async Task<IList<ContactViewModel>> SearchContacts(SearchContactModel searchModel)
        {
            IList<ContactViewModel> contacts = null;

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Contact/SearchContact", searchModel);

            if (response.IsSuccessStatusCode)
            {
                contacts = await response.Content.ReadAsAsync<IList<ContactViewModel>>();
            }
            return contacts;
        }

    }
}
