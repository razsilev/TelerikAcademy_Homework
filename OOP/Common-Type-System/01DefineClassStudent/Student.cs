using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01DefineClassStudent
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string GsmNumber { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }

        public Student(string firstName, string lastName, string ssn, Specialties specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = "";
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = "";
            this.GsmNumber = "";
            this.Email = "";
            this.Course = 0;
            this.Specialty = specialty;
        }

        public static bool operator ==(Student first, Student second)
        {
            if ((object)first == null && (object)second == null)
            {
                return true;
            }

            try
            {
                if (first.SSN.Equals(second.SSN))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool operator !=(Student first, Student second)
        {
            if (first == second)
            {
                return false;
            }

            return true;
        }

        // Override the Object.Equals(object o) method:
        public override bool Equals(object obj)
        {
            try
            {
                return this == (Student)obj;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static bool Equals(Student stud1, Student stud2)
        {
            return stud2 == stud1;
        }

        // Override the Object.GetHashCode() method:
        public override int GetHashCode()
        {
            return this.SSN.GetHashCode();
        }

        // Override the ToString method to convert Student to a string:
        public override string ToString()
        {
            return string.Format("name: {0} {1}, specialty {2}", this.FirstName, this.LastName, this.Specialty);
        }

        public Student Clone()
        {
            Student copy = new Student((string)this.FirstName.Clone(), (string)this.LastName.Clone(), (string)this.SSN.Clone(), this.Specialty);

            if (this.Address != null)
            copy.Address = this.Address.Clone() as string;

            copy.Course = this.Course;

            if (this.Email != null)
            copy.Email = this.Email.Clone() as string;
            
            copy.Faculty = this.Faculty;

            if (this.GsmNumber != null)
            copy.GsmNumber = this.GsmNumber.Clone() as string;

            if (this.MiddleName != null)
            copy.MiddleName = this.MiddleName.Clone() as string;
            
            copy.University = this.University;

            return copy;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student other)
        {
            return Student.CompareTo(this, other);
        }

        public static int CompareTo(Student firstStudent, Student secondStudent)
        {
            if (firstStudent != null && secondStudent != null)
            {
                if (firstStudent.FirstName.CompareTo(secondStudent.FirstName) > 0)
                {
                    return 1;
                }
                else if (firstStudent.FirstName.CompareTo(secondStudent.FirstName) == 0)
                {
                    if (firstStudent.MiddleName.CompareTo(secondStudent.MiddleName) > 0)
                    {
                        return 1;
                    }
                    else if (firstStudent.MiddleName.CompareTo(secondStudent.MiddleName) == 0)
                    {
                        if (firstStudent.LastName.CompareTo(secondStudent.LastName) > 0)
                        {
                            return 1;
                        }
                        else if (firstStudent.LastName.CompareTo(secondStudent.LastName) == 0)
                        {
                            return firstStudent.SSN.CompareTo(secondStudent.SSN);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
	        {
                throw new ArgumentNullException("Arguments can NOT be null.");
	        }
        }
    }
}
