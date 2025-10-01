namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string GuestName = string.Empty;
    public string RoomNumber = string.Empty;
    public DateTime CheckInDate;
    public DateTime CheckOutDate;
    public int TotalDays;
    public double RatePerDay;
    public double Discount;
    public double TotalAmount;

    public void BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
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

        LogBookingDetailsAsync();

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
    static void Run(string[] args)
    {
        Booking b = new Booking();
        b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        b.Cancel();
    }
}