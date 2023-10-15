using ElectronicJournalCourseProject.Data.DataContext;
using System.Collections.Generic;
using System.Text.Json;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Configuration;

namespace ElectronicJournalCourseProject.WPFApplication
{
    public static class EntryPoint
    {
        public static void StartApp()
        {
            string[] _options = {  };

            var _factory = new ElectronicJournalContextDesignTimeFactory();
            var context = _factory.CreateDbContext(_options);
            context.Database.EnsureCreated();
        }
    }
}
