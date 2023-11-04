class MindfulnessActivity
{
    protected string activityName;
    protected string description;
    protected int duration;

    public MindfulnessActivity(string name, string desc)
    {
        activityName = name;
        description = desc;
    }

    public void StartActivity(int duration)
    {
        this.duration = duration;
        Console.WriteLine($"Starting {activityName} - {description}");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds before starting
    }

    public void EndActivity()
    {
        Console.WriteLine($"Good job! You have completed {activityName}.");
        Console.WriteLine($"Activity duration: {duration} seconds");
        Console.WriteLine("Finishing...");
        Thread.Sleep(3000); // Pause for 3 seconds before finishing
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "Relax by deep breathing")
    {
    }

    public void StartBreathingActivity()
    {
        StartActivity(10); // Replace '10' with the user's specified duration
        for (int i = 0; i < duration; i++)
        {
            if (i % 2 == 0)
                Console.WriteLine("Breathe in...");
            else
                Console.WriteLine("Breathe out...");
            Thread.Sleep(2000); // Pause for 2 second
        }
        EndActivity();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity() : base("Reflection Activity", "Reflect on past experiences")
    {
    }

    public void StartReflectionActivity()
    {
        StartActivity(20); // Replace '20' with the user's specified duration
        // Add code to display prompts and questions here
        EndActivity();
    }
}

class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing Activity", "List positive things in your life")
    {
    }

    public void StartListingActivity()
    {
        StartActivity(15); // Replace '15' with the user's specified duration
        // Add code to display prompts and allow the user to list items
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartBreathingActivity();
                    break;

                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartReflectionActivity();
                    break;

                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartListingActivity();
                    break;

                case 4:
                    Environment.Exit(0);

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
