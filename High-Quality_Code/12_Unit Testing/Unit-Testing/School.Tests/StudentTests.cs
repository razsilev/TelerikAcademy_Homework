using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentWithEmptyNameShouldThrowAnExeption()
        {
            Student student = new Student("", 10100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentWithInvalidNumberShouldThrowAnExeption()
        {
            Student student = new Student("Pepi", 111);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStudentWhenJoinToCourseShouldThrowAnExeption()
        {
            var course = new Course(15);

            course.Join(null);
        }
    }
}
