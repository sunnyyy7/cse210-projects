using System;

// Address class for storing address details
public class Address
{
    private string street;
    private string city;
    private string state;
    private string zip;

    public Address(string street, string city, string state, string zip)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zip = zip;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state} {zip}";
    }
}

// Base Event class
public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GenerateStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GenerateFullDetails()
    {
        return GenerateStandardDetails();
    }

    public virtual string GenerateShortDescription()
    {
        return $"Type: Generic Event\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

// Derived class for Lectures
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Derived class for Receptions
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

// Derived class for Outdoor Gatherings
public class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string GenerateFullDetails()
    {
        return $"{base.GenerateFullDetails()}\nWeather: {weather}";
    }
}

// Program to demonstrate the Event classes
class Program
{
    static void Main()
    {
        // Create instances of each event type
        Address address = new Address("123 Main St", "Cityville", "State", "12345");
        Lecture lecture = new Lecture("Tech Talk", "Learn about new technologies", DateTime.Now, new TimeSpan(14, 30, 0), address, "John Doe", 50);
        Reception reception = new Reception("Networking Event", "Connect with professionals", DateTime.Now.AddDays(7), new TimeSpan(18, 0, 0), address, "rsvp@example.com");
        OutdoorGathering gathering = new OutdoorGathering("Park Picnic", "Enjoy the outdoors", DateTime.Now.AddDays(14), new TimeSpan(12, 0, 0), address, "Sunny");

        // Display messages for each event
        Console.WriteLine("Lecture:\n" + lecture.GenerateStandardDetails() + "\n\n" + lecture.GenerateFullDetails() + "\n\n" + lecture.GenerateShortDescription());
        Console.WriteLine("\nReception:\n" + reception.GenerateStandardDetails() + "\n\n" + reception.GenerateFullDetails() + "\n\n" + reception.GenerateShortDescription());
        Console.WriteLine("\nOutdoor Gathering:\n" + gathering.GenerateStandardDetails() + "\n\n" + gathering.GenerateFullDetails() + "\n\n" + gathering.GenerateShortDescription());
    }
}
