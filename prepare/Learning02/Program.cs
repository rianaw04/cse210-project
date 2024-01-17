using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2010;
        job1._endYear = 2015;


        Job job2 = new Job();
        job2._company = "Samsung";
        job2._jobTitle = "Graphic Designer";
        job2._startYear = 2016;
        job2._endYear = 2023;

        job1.Display();
        job2.Display();
    }

    //job1.Display();

}