using System;

// Base class: Event
class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string Address { get; set; }

    public virtual string GenerateMarketingMessage()
    {
        return $"Join us for the {Title} on {Date.ToShortDateString()} at {Time.ToString()}.\n{Description}\nLocation: {Address}";
    }
}

// Derived class: Lecture
class Lecture : Event
{
    public string SpeakerName { get; set; }
    public int Capacity { get; set; }

    public override string GenerateMarketingMessage()
    {
        return $"{base.GenerateMarketingMessage()}\nSpeaker: {SpeakerName}\nCapacity: {Capacity} seats available";
    }
}

// Derived class: Reception
class Reception : Event
{
    public string RsvpEmail { get; set; }

    public override string GenerateMarketingMessage()
    {
        return $"{base.GenerateMarketingMessage()}\nRSVP to: {RsvpEmail}";
    }
}

// Derived class: OutdoorGathering
class OutdoorGathering : Event
{
    public string WeatherInfo { get; set; }

    public override string GenerateMarketingMessage()
    {
        return $"{base.GenerateMarketingMessage()}\nWeather forecast: {WeatherInfo}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each event type
        Lecture lecture = new Lecture
        {
            Title = "Introduction to Farming",
            Description = "Learn about the basics of Farming.",
            Date = new DateTime(2023, 7, 20),
            Time = new TimeSpan(14, 0, 0),
            Address = "123 Main Street",
            SpeakerName = "John Doe",
            Capacity = 100
        };

        Reception reception = new Reception
        {
            Title = "Company Anniversary Celebration",
            Description = "Join us in celebrating our company's 10th anniversary.",
            Date = new DateTime(2023, 8, 5),
            Time = new TimeSpan(18, 30, 0),
            Address = "456 Park Avenue",
            RsvpEmail = "rsvp@example.com"
        };

        OutdoorGathering outdoorGathering = new OutdoorGathering
        {
            Title = "Summer Picnic",
            Description = "Enjoy a fun-filled day at our annual summer picnic.",
            Date = new DateTime(2023, 7, 30),
            Time = new TimeSpan(12, 0, 0),
            Address = "789 Oak Street",
            WeatherInfo = "Sunny with a temperature of 25°C"
        };

        // Display marketing messages for each event
        Console.WriteLine("Lecture Marketing Message:");
        Console.WriteLine(lecture.GenerateMarketingMessage());
        Console.WriteLine();

        Console.WriteLine("Reception Marketing Message:");
        Console.WriteLine(reception.GenerateMarketingMessage());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering Marketing Message:");
        Console.WriteLine(outdoorGathering.GenerateMarketingMessage());
    }
}
