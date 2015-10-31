using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void CreateSchool()
        {
            School school = new School();

            Assert.IsNotNull(school, "Can not create School object");
        }

        [TestMethod]
        public void CreateCorectCourceInSchool()
        {
            School school = new School();

            bool isCourseCreated = school.TryCreateCourse(33);

            Assert.IsTrue(isCourseCreated, "Can not create course.");
        }

        [TestMethod]
        public void CanNotCreateTwoEqualCourcesInSchool()
        {
            School school = new School();

            school.TryCreateCourse(33);
            bool isSecondCourseCreated = school.TryCreateCourse(33);

            Assert.IsFalse(isSecondCourseCreated, "Second course with exist course id mast not be created");
        }

        // Test join student to course
        [TestMethod]
        public void JoinStudentInCourse()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);

            school.TryCreateCourse(33);

            bool isStudentAdded = school.TryJoinStudentInCourse(pesho, 33);

            Assert.IsTrue(isStudentAdded, "Can not add student in course.");
        }

        [TestMethod]
        public void CanNotJoinMoreThenMaxStudentInCourse()
        {
            School school = new School();
            Student student = new Student("Pesho", 10100);

            school.TryCreateCourse(33);

            for (int i = 0; i < 30; i++)
            {
                var currentStudent = new Student("Pesho", 10005 + i);
                school.TryJoinStudentInCourse(currentStudent, 33);
            }

            bool isStudentAdded = school.TryJoinStudentInCourse(student, 33);

            Assert.IsFalse(isStudentAdded, "Can not add more then 30 students in course.");
        }

        [TestMethod]
        public void MastNotJoinExistedStudentInNotExistedCourse()
        {
            School school = new School();
            Student student = new Student("Pesho", 10100);

            school.TryCreateCourse(33);
            school.TryJoinStudentInCourse(student, 33);

            bool isStudentAddedToNotExistedCourse = school.TryJoinStudentInCourse(student, 5);

            Assert.IsFalse(isStudentAddedToNotExistedCourse, "Can not add student in course.");
        }

        [TestMethod]
        public void MastNotJoinNullStudentInCourse()
        {
            School school = new School();
            Student student = null;

            school.TryCreateCourse(33);

            bool isStudentAdded = school.TryJoinStudentInCourse(student, 33);

            Assert.IsFalse(isStudentAdded, "Can not add null student in course.");
        }

        [TestMethod]
        public void MastNotJoinStudentInNotExistedCourse()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);

            bool isStudentAdded = school.TryJoinStudentInCourse(pesho, 33);

            Assert.IsFalse(isStudentAdded, "Can not add student in not existed course.");
        }

        [TestMethod]
        public void JoinStudentToTwoDiferantCourses()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);

            school.TryCreateCourse(33);
            school.TryCreateCourse(15);

            bool isStudentAddedToCourse33 = school.TryJoinStudentInCourse(pesho, 33);
            bool isStudentAddedToCourse15 = school.TryJoinStudentInCourse(pesho, 15);

            bool isStudentJoinetToTwoCourses = isStudentAddedToCourse33 && isStudentAddedToCourse15;

            Assert.IsTrue(isStudentJoinetToTwoCourses, "Student is not joined to two courses.");
        }

        [TestMethod]
        public void CanNotHaveTwoStudentsInOneSchoolWithEqualNumbers()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);
            Student gosho = new Student("Gosho", 10100);

            school.TryCreateCourse(33);
            school.TryJoinStudentInCourse(pesho, 33);
            bool isGoshoJoinInCourse = school.TryJoinStudentInCourse(gosho, 33);

            Assert.IsFalse(isGoshoJoinInCourse, "Can not have in one school students whit equal numbers.");
        }

        // Test student leave course
        [TestMethod]
        public void StudentLeaveCourse()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);

            school.TryCreateCourse(33);
            school.TryJoinStudentInCourse(pesho, 33);

            var student = school.StudentLeaveCourse(10100, 33);

            Assert.IsNotNull(student, "Student can not be removed from cource.");
        }

        [TestMethod]
        public void StudentLeaveNotExistedCourse()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);

            school.TryCreateCourse(33);
            school.TryJoinStudentInCourse(pesho, 33);

            var student = school.StudentLeaveCourse(10100, 3);

            Assert.IsNull(student, "Student can not be removed from not existed cource.");
        }

        [TestMethod]
        public void NotExistedInSchoolStudentLeaveExistedCourse()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);

            school.TryCreateCourse(33);

            var student = school.StudentLeaveCourse(10100, 3);

            Assert.IsNull(student, "Student can not leave course when hi is not from this school");
        }

        [TestMethod]
        public void StudentChangeCourse()
        {
            School school = new School();
            Student pesho = new Student("Pesho", 10100);

            school.TryCreateCourse(33);
            school.TryCreateCourse(15);
            school.TryJoinStudentInCourse(pesho, 33);

            var student = school.StudentLeaveCourse(10100, 33);
            bool isStudentchangeCourse = school.TryJoinStudentInCourse(student, 15);

            Assert.IsTrue(isStudentchangeCourse, "Student can not change course.");
        }
    }
}
