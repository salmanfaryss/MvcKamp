using Bussiness.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void ChangeToFalse(Message p)
        {
            p.IsRead = false;
            _messageDal.Update(p);
        }

        public void ChangeToTrue(Message p)
        {
           p.IsRead = true;
            _messageDal.Update(p);
        }

        public void TDelete(Message p)
        {
            p.IsTrash = true;
            _messageDal.Update(p);
        }

        public Message TGetByID(int id)
        {
           
            
            return _messageDal.GetById(id);
        }

        public List<Message> TGetTrashList()
        {
            return _messageDal.List(x => x.IsTrash == true);
        }

        public List<Message> TGetIsReady()
        {
            return _messageDal.List(x => x.IsRead == true);
        }

        public List<Message> TGetList()
        {
           return _messageDal.GetList();
        }

        public List<Message> TGetListInbox(string p)
        {
            return _messageDal.List(x => x.Receiver == p);
        }

        public List<Message> TGetListSendBox(string p)
        {
            return _messageDal.List(x => x.Sender == p);
        }

        public void TInsert(Message p)
        {
           _messageDal.Insert(p);
        }

        public void TUpdate(Message p)
        {
           _messageDal.Update(p);
        }

      public  void ChangeToSpam(Message p)
        {
           
         p.IsSpam = true;
            _messageDal.Update(p);
        }

        public void RemoveFromSpam(Message p)
        {
           p.IsSpam = false;
           _messageDal.Update(p);
        }

        public List<Message> TGetSpamList(string p)
        {
            return _messageDal.List(x => x.Receiver == p && x.IsSpam == true);
        }
    }
}
