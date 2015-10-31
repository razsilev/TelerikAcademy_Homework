using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("grade can not be less then zero!");
            }

            this.grade = value;
        }
    }
    
    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("min grade can not be less then zero!");
            }

            this.minGrade = value;
        }
    }
    
    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentOutOfRangeException("max grade can not be less then or equal to min grade!");
            }

            this.maxGrade = value;
        }
    }
    
    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (value == null || value == "")
            {
                throw new ArgumentException("Comments can not be null or empty string!");
            }

            this.comments = value;
        }
    }
}
