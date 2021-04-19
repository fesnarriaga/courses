using Microsoft.AspNetCore.Mvc;
using ModelApp.MVC.Data;
using ModelApp.MVC.Models;
using System;
using System.Linq;

namespace ModelApp.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        public string Index()
        {
            // CREATE
            var student = new Student
            {
                Name = "Felipe Esnarriaga",
                Email = "f_esnarriaga@yahoo.com.br",
                BirthDate = DateTime.Now
            };
            _context.Students.Add(student);
            _context.SaveChanges();

            // READ
            var studentById = _context.Students.Find(student.Id);
            var studentByEmail = _context.Students.FirstOrDefault(x => x.Email == student.Email);
            var studentsList = _context.Students.Where(x => x.Name == student.Name);

            // UPDATE
            student.Name = "Felipe Duarte Esnarriaga";
            _context.Students.Update(student);
            _context.SaveChanges();

            // DELETE
            _context.Students.Remove(student);
            _context.SaveChanges();

            return "Well done!";
        }
    }
}
