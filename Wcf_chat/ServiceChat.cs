using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_chat
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nexId = 1;

        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nexId,
                Name = name,
                operationcontext = OperationContext.Current
            };
            nexId++;

            SendMsg($"{user.Name} подклячился к чату", 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg($"{user.Name} покинул чат", 0);
            }
        }

        public void SendMsg(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortDateString();

                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }
                answer += msg;

                item.operationcontext.GetCallbackChannel<IServerChatCallBack>().MsgCallBack(answer);
            }
        }
    }
}
