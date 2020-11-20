using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Refit;
namespace AwesomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        private string accessKey = "";

        public ChatPage()
        {
            InitializeComponent();
            Init();
        }
        public ChatPage(string _accessKey)
        {
            accessKey = _accessKey;
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            _messages = new ObservableCollection<string>();
            _messages.Add("Chat client started");
            listView.ItemsSource = _messages;
        }

        async void Handle_Send(object sender, System.EventArgs e)
        {
            if(!string.IsNullOrEmpty(message.Text))
            {
                var authAPI = RestService.For<IAuthAPI>("http://13.74.41.52:8082");
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("accesskey", accessKey);
                data.Add("message", message.Text);
               
                SimpleServerResponse res = await authAPI.SendMessage(data);
                if (res.result.Contains("Fail"))
                {
                    _messages.Add(res.result);
                }
                else
                {
                    data = new Dictionary<string, string>();
                    data.Add("accesskey", accessKey);

                    ChatMessages msgs = await authAPI.GetMessages(data);
                    if (msgs.result.Contains("Fail"))
                    {
                        _messages.Add(msgs.result);
                    }
                    else
                    {
                        _messages.Clear();
                        foreach(ChatMessageReceive s in msgs.chatmessages)
                        {
                            _messages.Add(s.nick + ": " + s.message);
                        }
                    }
                }
            }
                
        }
    }
}