using CosmeticsStore.Models;
using CosmeticsStore.Models.EF;
using Hangfire;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticsStore.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Services
        public ActionResult Index(string Searchtext, int? page)
        {
            IEnumerable<Service> items = db.Services.OrderBy(x => x.Title);
            var pageSize = 12;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(Searchtext))
            {
                char[] charArray = Searchtext.ToCharArray();
                bool foundSpace = true;
                //sử dụng vòng lặp for lặp từng phần tử trong mảng
                for (int i = 0; i < charArray.Length; i++)
                {
                    //sử dụng phương thức IsLetter() để kiểm tra từng phần tử có phải là một chữ cái
                    if (Char.IsLetter(charArray[i]))
                    {
                        if (foundSpace)
                        {
                            //nếu phải thì sử dụng phương thức ToUpper() để in hoa ký tự đầu
                            charArray[i] = Char.ToUpper(charArray[i]);
                            foundSpace = false;
                        }
                    }
                    else
                    {
                        foundSpace = true;
                    }
                }
                //chuyển đổi kiểu mảng char thàng string
                Searchtext = new string(charArray);
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            BackgroundJob.Schedule(() => UpdateBookingStatus(), TimeSpan.FromMinutes(15));

            return View(items);
        }
        public ActionResult SortByName(string Searchtext)
        {
            IEnumerable<Service> items = db.Services.OrderBy(x => x.Title).ToList();
            if (!string.IsNullOrEmpty(Searchtext))
            {
                char[] charArray = Searchtext.ToCharArray();
                bool foundSpace = true;
                //sử dụng vòng lặp for lặp từng phần tử trong mảng
                for (int i = 0; i < charArray.Length; i++)
                {
                    //sử dụng phương thức IsLetter() để kiểm tra từng phần tử có phải là một chữ cái
                    if (Char.IsLetter(charArray[i]))
                    {
                        if (foundSpace)
                        {
                            //nếu phải thì sử dụng phương thức ToUpper() để in hoa ký tự đầu
                            charArray[i] = Char.ToUpper(charArray[i]);
                            foundSpace = false;
                        }
                    }
                    else
                    {
                        foundSpace = true;
                    }
                }
                //chuyển đổi kiểu mảng char thàng string
                Searchtext = new string(charArray);
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            return View(items);
        }
        public ActionResult SortByPrice(string Searchtext)
        {
            IEnumerable<Service> items = db.Services.OrderBy(x => x.Price).ToList();
            if (!string.IsNullOrEmpty(Searchtext))
            {
                char[] charArray = Searchtext.ToCharArray();
                bool foundSpace = true;
                //sử dụng vòng lặp for lặp từng phần tử trong mảng
                for (int i = 0; i < charArray.Length; i++)
                {
                    //sử dụng phương thức IsLetter() để kiểm tra từng phần tử có phải là một chữ cái
                    if (Char.IsLetter(charArray[i]))
                    {
                        if (foundSpace)
                        {
                            //nếu phải thì sử dụng phương thức ToUpper() để in hoa ký tự đầu
                            charArray[i] = Char.ToUpper(charArray[i]);
                            foundSpace = false;
                        }
                    }
                    else
                    {
                        foundSpace = true;
                    }
                }
                //chuyển đổi kiểu mảng char thàng string
                Searchtext = new string(charArray);
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            return View(items);
        }
        public ActionResult SortByPriceGiam(string Searchtext)
        {
            IEnumerable<Service> items = db.Services.OrderByDescending(x => x.Price).ToList();
            if (!string.IsNullOrEmpty(Searchtext))
            {
                char[] charArray = Searchtext.ToCharArray();
                bool foundSpace = true;
                //sử dụng vòng lặp for lặp từng phần tử trong mảng
                for (int i = 0; i < charArray.Length; i++)
                {
                    //sử dụng phương thức IsLetter() để kiểm tra từng phần tử có phải là một chữ cái
                    if (Char.IsLetter(charArray[i]))
                    {
                        if (foundSpace)
                        {
                            //nếu phải thì sử dụng phương thức ToUpper() để in hoa ký tự đầu
                            charArray[i] = Char.ToUpper(charArray[i]);
                            foundSpace = false;
                        }
                    }
                    else
                    {
                        foundSpace = true;
                    }
                }
                //chuyển đổi kiểu mảng char thàng string
                Searchtext = new string(charArray);
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            return View(items);
        }
        public ActionResult SortByNameZA(string Searchtext)
        {
            IEnumerable<Service> items = db.Services.OrderByDescending(x => x.Title).ToList();
            if (!string.IsNullOrEmpty(Searchtext))
            {
                char[] charArray = Searchtext.ToCharArray();
                bool foundSpace = true;
                //sử dụng vòng lặp for lặp từng phần tử trong mảng
                for (int i = 0; i < charArray.Length; i++)
                {
                    //sử dụng phương thức IsLetter() để kiểm tra từng phần tử có phải là một chữ cái
                    if (Char.IsLetter(charArray[i]))
                    {
                        if (foundSpace)
                        {
                            //nếu phải thì sử dụng phương thức ToUpper() để in hoa ký tự đầu
                            charArray[i] = Char.ToUpper(charArray[i]);
                            foundSpace = false;
                        }
                    }
                    else
                    {
                        foundSpace = true;
                    }
                }
                //chuyển đổi kiểu mảng char thàng string
                Searchtext = new string(charArray);
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            return View(items);
        }
        public ActionResult Detail(string alias, int id)
        {
            var item = db.Services.Find(id);
            if (item != null)
            {
                db.Services.Attach(item);
                /*item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();*/
            }

            return View(item);
        }
        public List<HourModel> CurentDay(DateTime currentDate)
        {
            var startHour = 8;
            var endHour = 18;
            var hoursOfDay = new List<HourModel>();
            for (int i = 0; i < 96; i++) // 96 slot = 1 ngày (24 giờ x 4 slot/giờ)
            {
                var currentHour = currentDate.AddMinutes(i * 15);

                if (currentHour.Hour >= startHour && currentHour.Hour < endHour)
                {
                    var hourModel = new HourModel
                    {
                        Hour = currentHour,
                        IsPastTime = currentDate.Date == DateTime.Now.Date && currentHour <= DateTime.Now && currentHour.Date == DateTime.Now.Date
                    };
                    hoursOfDay.Add(hourModel);
                }
            }

            return hoursOfDay;
        }

        public bool IsBookingSlotAvailable(DateTime selectedHour, List<HourModel> bookedHours)
        {
            DateTime endHour = selectedHour.AddHours(1);

            foreach (var bookedHour in bookedHours)
            {
                // Kiểm tra nếu giờ được chọn nằm trong khoảng thời gian đã đặt
                if (selectedHour >= bookedHour.Hour && selectedHour < bookedHour.Hour.AddHours(1))
                {
                    return false;
                }

                // Kiểm tra nếu khoảng thời gian đã đặt nằm trong khoảng thời gian được chọn
                if (bookedHour.Hour >= selectedHour && bookedHour.Hour < endHour)
                {
                    return false;
                }
            }

            return true;
        }


        public ActionResult BookingTime()
        {
            //dat lịch
            string userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;

            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var name = user.FullName;
                ViewBag.name = name;
                Debug.WriteLine("Name: " + name);
                var email = user.Email;
                ViewBag.email = email;
                var phone = user.Phone;
                ViewBag.phone = phone;
                Debug.WriteLine("Phone: " + phone);
                // Thực hiện các thao tác khác với tên của user
            }
            DateTime currentDate = DateTime.Today.AddDays(0);
            List<List<HourModel>> hoursForDays = new List<List<HourModel>>();
            for (int i = 0; i < 7; i++)
            {
                var date = currentDate.AddDays(i);
                var hours = CurentDay(date);
                hoursForDays.Add(hours);
            }
            Debug.WriteLine(" Count: " + hoursForDays.Count());
            Debug.WriteLine(" IsPastTimne: " + hoursForDays[0][1].IsPastTime);
            ViewBag.HoursOfDay = hoursForDays;

            return View();
        }

        public ActionResult ConfirmBooking()
        {
           
            return View();
        }

        public ActionResult History()
        {
            string userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
                var phone = user.Phone;
            var appointments = db.Bookings.Where(b => b.Phone == phone)
                                           .OrderByDescending(b => b.Date)
                                           .ToList();

            // Chuyển đổi các bản ghi thành danh sách các đối tượng AppointmentViewModel
            var appointmentViewModels = new List<AppointmentViewModel>();
            foreach (var appointment in appointments)
            {
                var appointmentViewModel = new AppointmentViewModel
                {
                    Id = appointment.Id,
                    ServiceName = db.Services.FirstOrDefault(b => b.Id.ToString() == appointment.serviceId).Title,
                    Date = DateTime.Parse(appointment.Date),
                    Status = appointment.Status,
                    Code = appointment.Code,
                };
                appointmentViewModels.Add(appointmentViewModel);
            }

            // Truyền danh sách các đối tượng AppointmentViewModel vào ViewBag.History
            ViewBag.History = appointmentViewModels;

            return View();
        }

        
        public JsonResult CancelAppointment(string code)
        {
            var appointment = db.Bookings.FirstOrDefault(b => b.Code == code);
            if (appointment == null)
            {
                return Json(new { success = false, message = "Không tìm thấy đặt lịch." });
            }
            appointment.Status = "Đã hủy";
            db.SaveChanges();
            return Json(new { success = true, message = "Hủy đặt lịch thành công." });
        }

        public void UpdateBookingStatus()
        {
            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;

            // Lấy danh sách các đặt lịch chưa hoàn thành
            var bookings = db.Bookings.Where(b => b.Status != "Hoàn thành").ToList();

            // So sánh thời gian đặt lịch với thời gian hiện tại và cập nhật trạng thái
            foreach (var booking in bookings)
            {
                DateTime bookingDateTime;
                if (DateTime.TryParseExact(booking.Date, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out bookingDateTime))
                {
                    if (bookingDateTime < currentTime)
                    {
                        // Cập nhật trạng thái của đặt lịch
                        booking.Status = "Không hoàn thành";
                    }
                }
            }
            db.SaveChanges();
        }
    }


}