using System.Collections.Generic;

namespace MargunStore.Domain.Commands.v1.User.Create
{
    public class CreateUserCommandResponse
    {
        public delegate string GetNotification();

        public CreateUserCommandResponse(Data data) => Data = data;
        public CreateUserCommandResponse(List<string> notification) => Notifications = notification;

        public Data Data { get; set; }
        public List<string> Notifications { get; set; }
        
        public void AddErrorMessages(string message) => Notifications.Add(message);

        public void AddNotification(GetNotification notification) => Notifications.Add(notification());
    }

    public class Data
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
