using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("First name can not be null!");
            }

            if (value == string.Empty)
            {
                throw new ArgumentOutOfRangeException("First name can not be empty!");
            }

            this.firstName = value;
        }
    }
    
    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Last name can not be null!");
            }

            if (value == string.Empty)
            {
                throw new ArgumentOutOfRangeException("Last name can not be empty!");
            }

            this.lastName = value;
        }
    }
    
    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("exams can not be null!");
            }

            if (value.Count == 0)
            {
                throw new ArgumentOutOfRangeException("exams can not be empty!");
            }

            this.exams = value;
        } 
    }

    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
