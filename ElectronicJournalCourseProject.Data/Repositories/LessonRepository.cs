﻿using ElectronicJournalCourseProject.Data.Entities;

namespace ElectronicJournalCourseProject.Data.Repositories
{
    public class LessonRepository : ElectronicJournalBaseRepository<Lesson>
    {
        public LessonRepository() : base() 
        { }

        public List<Lesson> GetLessonsBySubjectName(string subjectName)
        {
            var res = from lessons in _context.Lessons
                      join loadList in _context.LoadLists on lessons.LoadListId equals loadList.LoadListId
                      join plan in _context.Plans on loadList.PlanId equals plan.PlanId
                      join subject in _context.Subjects on plan.SubjectId equals subject.SubjectId
                      where subject.SubjectName == subjectName
                      select lessons;

            return res.ToList();
        }

        public List<DateTime> GetLessonDatesBySubjectNameForGroup(string subjectName, string abbreviature, int teacherId)
        {
            var res = from lessons in _context.Lessons
                      join loadList in _context.LoadLists on lessons.LoadListId equals loadList.LoadListId
                      join plan in _context.Plans on loadList.PlanId equals plan.PlanId
                      join subject in _context.Subjects on plan.SubjectId equals subject.SubjectId
                      where subject.SubjectName == subjectName && loadList.Group.Abbreviature == abbreviature
                      select lessons;

            var dtList = new List<DateTime>();

            foreach(var lesson in res.ToList())
                dtList.Add(lesson.LessonDate);
            
            return dtList;
        }
    }
}
