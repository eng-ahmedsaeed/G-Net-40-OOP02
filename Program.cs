//Part 01 : Theoretical Questions

//Q1
//[a] the balance is exposed as a public property which allows any one to access and modifiy it directly, which can lead to unintended consequences and bugs in the code. 
//[b] Encapsulation is the principle of hiding the internal details of an object and exposing only what is necessary to the outside world. In this case, we can make the balance property private and the Owner as private  and provide public properties to access and modifiy it  . This way, we can control how the balance is modified and ensure that it remains consistent with the business rules of the application.
//[c] exposing fields as public violates the princip;le of encabsulation in oop as  it allows direct access and change to the internal state of the object which must be hidden from the user and these can lead to unintended consequences and bugs in the code. By using properties instead of fields, we can control how the data is accessed and modified, and ensure that it remains consistent with the business rules of the application, the user should access using the properties or getter and setters to apply validations and other busniess logic 
//==================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
//Q2
//the difference between field and property in C# is that the field is a variablethat is declared directly in the class and is used to stor data while property is a a member that provides accessing to the data of the class (Fields) or a calculated data ,it is a way to encapsulate the data and provide a controlled access to it, properties can have getter and setter methods that allow you to control how the data is accessed and modified which can  hold some logic, while fields do not have this capability
//An example of read only property in C# is the PI property in the Math class, which is a constant value that cannot be modified. It is defined as follows:
/*
 * private const double PI = 3.14159265358979323846;
 * public static double Pi{
 *      get { return PI; }
 * }
 */
//==================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
//Q3
//[a] this[int Index] these Called indexer its purpose is to Allowe object to be indexed like an array , it is a way to provide a convenient syntax for accessing elements of a collection or an array that is encapsulated within a class.
//[b] these May throw Exception if the index is out of range or if the collection is null, it is important to handle these exceptions properly to avoid crashes and ensure that the application behaves as expected. It is also important to validate the input index before accessing the collection to prevent these exceptions from occurring in the first place.
//  public string this [int index]{
// get {if (index>5) 
//        console.WriteLine("index is out of range");
//      else
//	{
//				return "value at index " + index;
//	}
//[c] yes the class could have more than one indexer which is known as overloading indexers, this allows the class to provide multiple ways to access its data using different types of indices. For example, a class could have one indexer that takes an integer index and another indexer that takes a string index, allowing the user to access the data in different ways depending on their needs. However, it is important to ensure that the indexers are implemented correctly and do not cause confusion for the user when accessing the data.
//==================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================
//Q4
//[a] these means that these data field is not related to foreach Instance of the class but rather iterator is shared among all the instencies of the class , its called using the class name , on the other hand the item is the normal data field which iterator bonded to foreach instance and could me accessed using the Pointer of these specific instance
//[b] No static Methods cannot access non static data field because static methods are not associated with any instance of the class and do not have access to instance-specific data. Non-static data fields are tied to specific instances of the class, and static is tied to the class itself, so it cannot access instance-specific data. To access non-static data fields, you need to create an instance of the class and use that instance to access the data field.

public enum Tickettype_e {
    Standard,
        VIP,
        IMAX
}

public struct Seat_e
{
    char Row;
    int Number;
}

public class Ticket {

    ///////////1
    private String? moviename ;
    private double price ;
    public int TicketId { set; get; }
    public  String MovieName{
    get{ return moviename; }    
    set{
            if (value == null)
                return;
            else
                moviename = value;

        
    }
    }

    public Tickettype_e TicketType{  get;set;}
    public Seat_e Seat { get; set; }
    public double Price
    {
        get { return price; }
        set {
            if (value < 0)
                return;
            price = value;
        }

    }
    public double  PriceAfterTax => (price + (price * (14.00 / 100)));
    ///////////////////2
    static int ticketCount;
    public Ticket()
    {
        ticketCount ++;
        TicketId = ticketCount;

    }
     public static int GetTotalticketsSold()
    { return ticketCount; }
}


////////////3
public class Cinema
{
   private Ticket[] Tickets;
   
   public Cinema()
    {
        Tickets = new Ticket[20];

    }

    public Ticket this[int i]
    {
        get
        {
            if (i >= 20 || i<0)
                return null;
            return Tickets[i];
        }
        set
        {
            if (i >= 20)
                return;
            Tickets[i] = value;
        }

    }

    public Ticket GetMovie(String m){

        foreach (Ticket t  in Tickets)
        {
            if(t != null && t.MovieName == m)
            return t;
            
        }
        return null;
    }

    public bool AddTicket (Ticket t)
    {
        for (int i = 0; i < Tickets.Length; i++)
        {
            
        
            if (Tickets[i] == null)
            {
                Tickets[i] = t;
                return true;
            }
        
        }
            return false;
    }



        
}

/// ////////4

public class BookingHelper
{
    static int counter=0;
    public static double CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
    {
        if (numberOfTickets >= 5)
            return (numberOfTickets * pricePerTicket)*90.0/100 ;
        return (numberOfTickets * pricePerTicket);
    }

    public static string GenerateBookingReference() {
        counter++;
        return "BK-" + counter;
    }
}
////////5
public class Console
{
    static void Main(string[] args)
    {
        Ticket t1 = new Ticket();
        System.Console.WriteLine("Please Enter Data for Ticket 1");
        System.Console.WriteLine("Movie Name: ");
        t1.MovieName = System.Console.ReadLine();
        System.Console.WriteLine("Ticket Type (0-Standard,1-Vip,2-Imax): ");
         bool flag =int.TryParse(System.Console.ReadLine(),out  int type);



    }
}