//A C# Console App wherein the user
//inputs the hours and minutes of the analogue
//clock.

//The program calculates the lesser angle in degrees
//between the hour hand and the minute hand and
//outputs the answer in the console window.

using System;

class clockAngle
{

    //Function to calculate the angle
    static float calcAngle(double h, double m)
    {
        //Input Validation
        if (h < 0 || m < 0 ||
            h > 12 || m > 60)
            Console.Write("Invalid input.");

        //Set 12:00 as origin
        if (h == 12)
            h = 0;

        //If user inputs minutes as 60, automatically calculate
        //it as the next hour and set minute at 0 instead.
        if (m == 60)
        {
            m = 0;
            h += 1;

            //If this calculation exceeds 12 (12:60),
            //Convert hour to 1
            if (h > 12)
                h = h - 12;
        }

        //The hour hand moves 30 degrees every hour 
        //and 0.5 degrees every minute.
        float hour_angle = (float)((30 * h) + (0.5 * m));

        //Minute hand moves 6 degrees every minute.
        float minute_angle = (float)(6 * m);

        //Find the difference between two angles
        //in absolute value.
        float angle = Math.Abs(hour_angle - minute_angle);

        //We are looking for the lesser angle so we
        //take the smaller value between two possible angles
        //(Hour Hand to Minute Hand) vs (Minute Hand to Hour Hand)
        angle = Math.Min(360 - angle, angle);

        return angle;
    }

    //Driver Code
    public static void Main()
    {
        Console.Write("Input Hour: ");
        string stringHour = Console.ReadLine();
        int inputHour = Convert.ToInt32(stringHour);
        Console.Write("Input Minutes: ");
        string stringMins = Console.ReadLine();
        int inputMins = Convert.ToInt32(stringMins);
        Console.WriteLine("The lesser angle for the time " + stringHour
            + ":" + stringMins + " is " + calcAngle(inputHour, inputMins)
            + " degrees.");
    }
}