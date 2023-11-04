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

            if (choice == 4)
                break;

            Console.Write("Enter the duration (in seconds): ");
            int duration = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var breathingActivity = new BreathingActivity(duration);
                    breathingActivity.PerformBreathingActivity();
                    break;

                case 2:
                    var reflectionActivity = new ReflectionActivity(duration);
                    reflectionActivity.PerformReflectionActivity();
                    break;

                case 3:
                    var listingActivity = new ListingActivity(duration);
                    listingActivity.PerformListingActivity();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    public void PerformBreathingActivity()
    {
        Start();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        ShowCountdown();

        Console.WriteLine("\nBreathe in...");
        ShowCountdown();

        Console.WriteLine("\nBreathe out...");
        ShowCountdown();

        End();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public void PerformReflectionActivity()
    {
        Start();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        ShowCountdown();

        Random random = new Random();
        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            ShowCountdown();

            private List<string> reflectionQuestions;

    public ReflectionActivity(int duration) : base(duration)
    {
        reflectionQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

        }

        End();
    }
}

class ListingActivity : MindfulnessActivity
{
    private static List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public void PerformListingActivity()
    {
        Start();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        ShowCountdown();

        Random random = new Random();
        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            ShowCountdown();

            
            public void PerformReflectionActivity()
{
        Start();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        ShowCountdown();

        Random random = new Random();
        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            ShowCountdown();

            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine(question);
                ShowCountdown();
            }
        }

        End();
    }

        }

        End();
    }
}


