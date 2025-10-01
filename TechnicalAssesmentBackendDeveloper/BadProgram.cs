namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string GuestName { get; set; } = string.Empty;
    public string RoomNumber { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int TotalDays { get; set; }
    public double RatePerDay { get; set; }
    public double Discount { get; set; }
    public double TotalAmount { get; set; }

    public async Task BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkin;
        CheckOutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        TotalDays = (checkout - checkin).Days;
        TotalAmount = TotalDays * RatePerDay;
        TotalAmount = TotalAmount - (TotalAmount * Discount / 100);

        await LogBookingDetailsAsync();

        Console.WriteLine("Room Booked for " + GuestName);
        Console.WriteLine("Room No: " + RoomNumber);
        Console.WriteLine("Check-In: " + CheckInDate.ToString());
        Console.WriteLine("Check-Out: " + CheckOutDate.ToString());
        Console.WriteLine("Total Days: " + TotalDays);
        Console.WriteLine("Amount: " + TotalAmount);
    }

    public async Task LogBookingDetailsAsync()
    {
        // Simulate writing to a log file or remote system
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        GuestName = string.Empty;
        RoomNumber = string.Empty;
        CheckInDate = DateTime.MinValue;
        CheckOutDate = DateTime.MinValue;
        RatePerDay = 0;
        Discount = 0;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled");
    }
}

public static class AppHost
{
    static async Task Run(string[] args)
    {
        Booking b = new Booking();
        await b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        b.Cancel();
    }
}