using System;
using ElectronicJournalCourseProject.Data.Repositories;

namespace ElectronicJournalCourseProject.Tests
{
    public class ReposTests
    {
        private LoadListRepository _loadListRepository;
        private GroupRepository _groupRepository;

        [SetUp]
        public void Setup()
        {
            _loadListRepository = new LoadListRepository();
            _groupRepository = new GroupRepository();
        }

        [Test]
        public void GetLoadLists()
        {
            var res = _loadListRepository.GetListOfItem();
            Assert.IsNotNull(res.First().Group);
        }

        [Test]
        public void GetList()
        {
            var res = _groupRepository.GetListOfItem().ToList();
            var res1 = res.First().LoadList;
            Console.Write(res1);
            Assert.IsNotNull(res.First().Specialty);
        }
    }
}
