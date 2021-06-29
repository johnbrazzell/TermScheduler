using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TermScheduler
{
    public static class DBService
    {
        static SQLiteAsyncConnection db;
        public static async Task Init()
        {
            
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TermData.db");

            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Term>();
            await db.CreateTableAsync<Course>();
        }

      

        public static async Task AddTerm(string termName, DateTime startDate, DateTime endDate, bool startNotifications, bool endNotifications)
        {
            await Init();
            var term = new Term
            {
                TermName = termName,
                TermStart = startDate,
                TermEnd = endDate,
                TermStartNotifications = startNotifications,
                TermEndNotifications = endNotifications

            };

            var id = await db.InsertAsync(term);
        }

        public static async Task DeleteTerm(int id)
        {
            await Init();

            await db.DeleteAsync<Term>(id);
        }

        public static async Task CreateCourseTable()
        {
            await db.CreateTableAsync<Course>();
        }

        public static async Task DropCourseTable()
        {
            await db.DropTableAsync<Course>();
        }

        public static async Task<IEnumerable<Term>> GetTerms()
        {
            await Init();
            var terms = await db.Table<Term>().ToListAsync();
            return terms;
        }

        public static async Task AddCourse(string courseName, int termID, DateTime courseStart, DateTime courseEnd, string courseStatus, string instructorName,
                                            string instructorPhone, string instructorEmail, bool courseStartNotifications,
                                            bool courseEndNotifications, string objName, DateTime objStart, DateTime objEnd,
                                            bool objStartNotifications, bool objEndNotifications, string perfName, 
                                            DateTime perfStart, DateTime perfEnd, bool perfStartNotifications, bool perfEndnotifications,
                                            string notes)
        {
            await Init();
            var course = new Course
            {
                Name = courseName,
                TermID = termID,
                CourseStartDate = courseStart,
                CourseEndDate = courseEnd,
                CourseStatus = courseStatus,
                CourseStartNotifications = courseStartNotifications,
                CourseEndNotifications = courseEndNotifications,
                InstructorName = instructorName,
                InstructorPhoneNumber = instructorPhone,
                InstructorEmail = instructorEmail,
                ObjectiveAssessmentName = objName,
                ObjectiveStart = objStart,
                ObjectiveEnd = objEnd,
                ObjectiveAssessmentStartNotifications = objStartNotifications,
                ObjectiveAssessmentEndNotifications = objEndNotifications,
                PerformanceAssessmentName = perfName,
                PerformanceStart = perfStart,
                PerformanceEnd = perfEnd,
                PerformanceAssessmentStartNotifications = perfStartNotifications,
                PerformanceAssessmentEndNotifications = perfEndnotifications,
                CourseNotes = notes

            };

            await db.InsertAsync(course);
        }

        public static async Task DeleteCourse(int id)
        {
            await Init();

            await db.DeleteAsync<Course>(id);
        }


        public static async Task<IEnumerable<Course>> GetClasses()
        {
            await Init();
            var courses = await db.Table<Course>().ToListAsync();
            return courses;
        }



    }
}
