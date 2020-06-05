using DesktopAppChat.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Net;
using System.IO;
using DesktopAppChat.Data;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;
using System.Windows.Data;

namespace DesktopAppChat.ViewModel
{
    class ChatViewModel : ViewModelBase
    {
        HubConnection hubConnection;
        public ObservableCollection<MessageData> Messages { get; set; }
        bool isConnected;
        bool isBusy;
        private string message;

        private ICommand sendMessageCommand;
        private ICommand connect;
        private ICommand disconnect;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged("IsBusy");
                }
            }
        }


        public bool IsConnected
        {
            get => isConnected;
            set
            {
                if (isConnected != value)
                {
                    isConnected = value;
                    OnPropertyChanged("IsConnected");
                }
            }
        }

        public ICommand ChatConnect
        {
            get
            {
                if (connect == null)
                {
                    connect = new DelegateCommand(async () => await Connect());
                }
                return connect;
            }
        }

        public ICommand ChatDisconnect
        {
            get
            {
                if (disconnect == null)
                {
                    disconnect = new DelegateCommand(async () => await Disconnect());
                }
                return disconnect;
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                if (sendMessageCommand == null)
                {
                    sendMessageCommand = new DelegateCommand(async () => await SendMessage());
                }
                return sendMessageCommand;
            }
        }

        public ChatViewModel()
        {
            hubConnection = new HubConnectionBuilder()
               .WithUrl("http://127.0.0.1:60737/chat")
               .Build();
            Messages = new ObservableCollection<MessageData>();
            IsConnected = false;
            IsBusy = false;
            hubConnection.Closed += async (error) =>
            {
                SendLocalMessage(string.Empty, "Подключение закрыто...");
                IsConnected = false;
                await Task.Delay(5000);
                await Connect();
            };
            hubConnection.On<string, string>("Send", (user, message) =>
            {
                SendLocalMessage(user, message);
            });
        }
        //Подключение к чату
        public async Task Connect()
        {
            if (IsConnected)
                return;
            try
            {
                await hubConnection.StartAsync();
                SendLocalMessage(string.Empty, "Вы вошли в чат...");
                IsConnected = true;
            }
            catch (Exception ex)
            {
                SendLocalMessage(string.Empty, $"Ошибка подключения: {ex.Message}");
            }
        }

        // Отключение от чата
        public async Task Disconnect()
        {
            if (!IsConnected)
                return;

            await hubConnection.StopAsync();
            IsConnected = false;
            SendLocalMessage(string.Empty, "Вы покинули чат...");
        }

        // Отправка сообщения
        async Task SendMessage()
        {
            try
            {
                IsBusy = true;
                await hubConnection.InvokeAsync("Send", UserDataStatic.Login, Message);
            }
            catch (Exception ex)
            {
                SendLocalMessage(string.Empty, $"Ошибка отправки: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
        // Добавление сообщения
        private void SendLocalMessage(string user, string message)
        {
            try
            {
                Messages.Insert(0, new MessageData
                {
                    Message = message,
                    UserName = user,
                    Time = DateTime.Now.ToString()
                });
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message);
            }
            BindingOperations.EnableCollectionSynchronization(Messages, 1);
        }

    }
}