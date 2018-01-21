using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenon.BusinessLogic.Interface;
using Xenon.BusinessLogic.Models;

namespace Xenon.BusinessLogic.Controllers
{
  public class AdminAction : IAdminAction
  {

    public void AddUpdateStatusUser(UpdateStatus us)
    {
      using (var ctx = new BusinessContext())
      {
        us.SubmitTimeStamp = DateTime.Now;
        ctx.UpdateStatuses.Add(us);
        ctx.SaveChanges();
      }
    }


    public void AcceptUpdateStatusUser(UpdateStatus us)
    {
      using (var ctx = new BusinessContext())
      {
        var toAccept = GetUpdateStatusById(us.Id);
        toAccept.InProgress = false;
        toAccept.AnswerTimeStamp = DateTime.Now;
        ctx.Entry(toAccept).State = System.Data.Entity.EntityState.Modified;

        EditUserStatus(us.UserId, us.NewStatus, us.Path);

        ctx.SaveChanges();
      }
    }

    public void RefuseUpdateStatusUser(UpdateStatus us)
    {
      using (var ctx = new BusinessContext())
      {
        var toRefuse = GetUpdateStatusById(us.Id);
        toRefuse.InProgress = false;
        toRefuse.AnswerTimeStamp = DateTime.Now;
        ctx.Entry(toRefuse).State = System.Data.Entity.EntityState.Modified;
        ctx.SaveChanges();
      }
    }

    public List<UpdateStatus> GetUpdateStatus(bool inProgress)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from us in ctx.UpdateStatuses
                    where us.InProgress.Equals(inProgress)
                    select us;

        return query.ToList();
      }
    }



    private UpdateStatus GetUpdateStatusById(Guid id)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from us in ctx.UpdateStatuses
                    where us.Id.Equals(id)
                    select us;

        return query.FirstOrDefault();
      }
    }


    private bool EditUserStatus(Guid userId, string status, string filename)
    {
      using (var ctx = new BusinessContext())
      {
        var query = from u in ctx.Users
                    where u.Id.Equals(userId)
                    select u;
        User usr = query.FirstOrDefault();

        if (usr == null)
        {
          return false;
        }
        else
        {
          usr.Status = status;
          ctx.Entry(usr).State = System.Data.Entity.EntityState.Modified;
          ctx.SaveChanges();

          return true;
        }

      }

    }
  }
}
