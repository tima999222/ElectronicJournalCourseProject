using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    private StudentRepository _studentRepository;
    private TeacherRepository _teacherRepository;

    public LoginRepository()
    {
        _studentRepository = new StudentRepository();
        _teacherRepository = new TeacherRepository();
    }

    public bool ValidateTeacher(string login, string password)
    {
        var teachers = _teacherRepository.GetListOfItem();
        var result = teachers.FirstOrDefault(t => t.Login == login && t.Password == password);
        if (result == null) return false;
        return true;
    }

    public bool ValidateStudent(string login, string password)
    {
        var students = _studentRepository.GetListOfItem();
        var result = students.FirstOrDefault(s => s.Login == login && s.Password == password);
        if (result == null) return false;
        return true;
    }
}
