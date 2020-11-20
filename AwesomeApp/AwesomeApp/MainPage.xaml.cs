using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Refit;
namespace AwesomeApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        int count = 0;
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
        }
        async void Handle_Login(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(nick.Text) && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(nickname.Text))
            {
                var authAPI = RestService.For<IAuthAPI>("http://13.74.41.52:8082");
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("username", nick.Text);
                data.Add("password", password.Text);
                data.Add("chatnick", nickname.Text);
                UserAccess result = await authAPI.Login(data);
                infoLabel.Text = result.result.ToString();
                if(!result.result.Contains("Fail"))
                {
                    await Navigation.PushAsync(new ChatPage(result.accesskey));
                }
                //infoLabel.Text = "User " + nick.Text + " was not found";
            }
                
        }
        async void Handle_Register(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(nick.Text) && !string.IsNullOrEmpty(password.Text))
            {
                var authAPI = RestService.For<IAuthAPI>("http://13.74.41.52:8082");
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("username", nick.Text);
                data.Add("password", password.Text);
                SimpleServerResponse res = await authAPI.Register(data);
                infoLabel.Text = res.result.ToString();
                //infoLabel.Text = nick.Text + " has been registered";
            }
        }
    }
}
