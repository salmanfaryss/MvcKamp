using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IMessageService
    {
        List<Message> TGetList();
        List<Message> TGetListInbox(string p);
        List<Message> TGetListSendBox(string p);
        List<Message> TGetTrashList();
        List<Message> TGetIsReady();
        void ChangeToSpam(Message p);
        void RemoveFromSpam(Message p);
        List<Message> TGetSpamList(string p);

        void TInsert(Message p);
        void TUpdate(Message p);
        void TDelete(Message p);
        Message TGetByID(int id);
        void ChangeToTrue(Message p);
        void ChangeToFalse(Message p);

       
    }
}
