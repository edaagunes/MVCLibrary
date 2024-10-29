using System.Linq;
using System.Web.Mvc;
using MVCLibrary.Models;
using MVCLibrary.Models.Entity; // Model sınıfınıza göre güncelleyebilirsiniz

public class GlobalViewBagAttribute : ActionFilterAttribute
{
    private readonly LibraryDbEntities _context;

    public GlobalViewBagAttribute()
    {
        _context = new LibraryDbEntities(); // Veritabanı bağlamını başlatın
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var sessionMail = filterContext.HttpContext.Session["Mail"] as string;

        if (!string.IsNullOrEmpty(sessionMail))
        {
            // Giriş yapan kullanıcıya göre verileri al
            var member = _context.Member.FirstOrDefault(x => x.Mail == sessionMail);
            if (member != null)
            {
                // ViewBag değerlerini atayın
                filterContext.Controller.ViewBag.name = member.Name + " " + member.Surname;
                filterContext.Controller.ViewBag.photo = member.Photo;
                filterContext.Controller.ViewBag.username = member.Username;
                filterContext.Controller.ViewBag.school = member.School;
                filterContext.Controller.ViewBag.phone = member.Phone;
                filterContext.Controller.ViewBag.mail = member.Mail;

                // Ekstra sayılar gibi bilgileri atayın
                filterContext.Controller.ViewBag.book = _context.Sale.Where(x => x.Member == member.MemberID).Count();
                filterContext.Controller.ViewBag.message = _context.Message.Where(x => x.Receiver == sessionMail).Count();
                filterContext.Controller.ViewBag.notice = _context.Announcement.Count();
            }
        }

        base.OnActionExecuting(filterContext);
    }
}
