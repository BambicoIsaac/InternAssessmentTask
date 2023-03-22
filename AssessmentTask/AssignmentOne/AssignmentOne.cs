//A C# Console App wherein the user
//inputs the hours and minutes of the analogue
//clock.

//The program calculates the lesser angle in degrees
//between the hour hand and the minute hand and
//outputs the answer in the console window.

class AssignmentOne
{
    //Time Constructor
    public class Time
    {
        public int hour;
        public int minute;

        public Time(int inputHour, int inputMinute)
        {
            hour = inputHour;
            minute = inputMinute;
        }
    }

    //Transform inputted time in a way that our calculator can interpret.
    public static Time Validate(Time givenTime)
    {
        //Check for Invalid input
        if (givenTime.hour < 0 || givenTime.minute < 0 ||
            givenTime.hour > 12 || givenTime.minute > 60)
        {
            Console.Write("Invalid input.");
            Environment.Exit(0);
        }            

        //Set 12:00 as origin
        if (givenTime.hour == 12)
            givenTime.hour = 0;

        //If user inputs minutes as 60, automatically calculate
        //it as the next hour and set minute at 0 instead.
        if (givenTime.minute == 60)
        {
            givenTime.minute = 0;
            givenTime.hour += 1;

            //If this calculation exceeds 12 (12:60),
            //Convert hour to 1
            if (givenTime.hour > 12)
                givenTime.hour = givenTime.hour - 12;
        }
        Time processedTime = new Time(givenTime.hour, givenTime.minute);
        return processedTime;
    }

    //Transform processed time into standard way of writing time
    public static string ConvertTimeToString(Time processedTime)
    {
        string stringedHour = "0";
        string stringedMinute = "0";
        
        //If single digit hour, append processed hour into the string
        if (processedTime.hour < 10)
        {
            stringedHour += (processedTime.hour.ToString());
        }

        //If not single digit, just use the whole processed hour.
        else
        {
            stringedHour = processedTime.hour.ToString();
        }
        
        //If minutes only has a single digit, append processed minute into the string
        if (processedTime.minute < 10)
        {
            stringedMinute += (processedTime.minute.ToString());
        }

        //If not single digit, just use the whole processed minute.
        else
        {
            stringedMinute = processedTime.minute.ToString();
        }

        //Put the stringed hour and minute in a string that writes the times in standard way of writing time. (HH:MM)
        string stringedInterpretedTime = stringedHour + ":" + stringedMinute;
        return stringedInterpretedTime;        
    }

    //Constructor that converts the processed hour and minute to their angle equivalents.
    public class TimeInAngle
    {
        public float hourInAngle;
        public float minuteInAngle;

        public TimeInAngle(int hourToAngle, int minuteToAngle)
        {
            //The hour hand moves 30 degrees every hour 
            //and 0.5 degrees every minute.
            hourInAngle = (float)((30 * hourToAngle) + (0.5 * minuteToAngle));

            //Minute hand moves 6 degrees every minute.
            minuteInAngle = (6 * minuteToAngle);
        }
    }

    //Function to calculate the lesser angle.
    public static float CalculateLesserAngle(float angleOfHour, float angleOfMinute)
    {
        float hourAngle = angleOfHour;
        float minuteAngle = angleOfMinute;

        //Find the difference between two angles
        //in absolute value.
        float calculatedAngle = Math.Abs(hourAngle - minuteAngle);

        //We are looking for the lesser angle so we
        //take the smaller value between two possible angles
        //(Hour Hand to Minute Hand) vs (Minute Hand to Hour Hand)
        calculatedAngle = Math.Min(360 - calculatedAngle, calculatedAngle);

        return calculatedAngle;
    }

    //Driver Code
    public static void Main()
    {
        //Get Hour value
        Console.Write("Input hour: ");
        int Hour = Convert.ToInt32(Console.ReadLine());

        //Get Minute value
        Console.Write("Input minute: ");
        int Minute = Convert.ToInt32(Console.ReadLine());

        //Create a time object with its values given
        //by validating the input values using our Validate function
        Time InterpretedTime = Validate(new Time(Hour, Minute));

        //Store the interpreted time converted to a string using our ConverTimeToString
        //into a string variable to be used for the output.
        string stringedInterpretedTime = ConvertTimeToString(InterpretedTime);

        //Converts the interpreted hour and minute to their angle equivalents.
        TimeInAngle interpretedTimeInAngle = new TimeInAngle(InterpretedTime.hour, InterpretedTime.minute);

        //Calculate the lesser angle given the angles obtained from our TimeInAngle constructor.
        float lesserAngle = CalculateLesserAngle(interpretedTimeInAngle.hourInAngle, interpretedTimeInAngle.minuteInAngle);

        //Print the output
        Console.WriteLine("The lesser angle for the time " + stringedInterpretedTime + " is " + lesserAngle + " degrees.");        
    }
}