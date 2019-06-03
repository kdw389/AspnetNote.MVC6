using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using AspnetNote.MVC6.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //ID와 비밀번호 - 필수
            if(ModelState.IsValid)
            {
                using (var db = new AspnetNoteDBContext())
                {
                    // Linq 쿼리식 - 메서드 체이닝
                    // 람다식 => : A Go To B 
                    // u -> 익명 인수
                    // == 비교는 메모리 누수가 발생함.
                    //var user = db.Users.FirstOrDefault(u => u.UserId == model.UserId && u.UserPassword == model.UserPassword);

                    var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));

                    //var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId));

                    if (user != null)
                    {
                        //로그인에 성공했을 때
                        //HttpContext.Session.SetInt32(string key, int value); key - 식별자 value - 사용자 정보
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");    //로그인 성공 페이지로 이동
                    }
                    //else
                    //{
                    //    //사용자 ID 자체가 회원가입 X 경우
                    //    //ModelState.AddModelError(string.Empty, "사용자 ID가 존재하지 않습니다.");
                    //}
                }
                    //로그인에 실패했을 때
                    ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            //모든 Session 삭제
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");    //로그인 성공 페이지로 이동
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 회원가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                // Java try(SqlSession){} catch(){}

                // C#
                using (var db = new AspnetNoteDBContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                //HomeController의 Index View로 넘긴다.
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
