namespace factory_pattern
{
    //A demonstration of the Factory pattern in C#
    public class Program
    {
        static void Main(string[] args)
        {
            //Each Transporter can be created based on the desired type.
            Transporter transporterOne = new RoadTransporter();
            Transporter transporterTwo = new SeaTransporter();

            //Each Transporter will return the chosen Transport type - the logic is hidden which is important.
            ITransport transportOne = transporterOne.CreateTransport();
            ITransport transportTwo = transporterTwo.CreateTransport();

            //Regardless of the transporter type, we simply invoke Deliver and it does the work for us.
            transportOne.Deliver();
            transportTwo.Deliver();

            /* OUTPUT:
             * 
             * Truck delivery
             * Boat delivery
             */
        }
    }

    //Create an interface that both of our transport types can use. All transport types must be able to deliver.
    public interface ITransport
    {
        void Deliver();
    }

    public class Truck : ITransport
    {
        void ITransport.Deliver()
        {
            Console.WriteLine("Truck delivery");
        }
    }

    public class Boat : ITransport
    {
        void ITransport.Deliver()
        {
            Console.WriteLine("Boat delivery");
        }
    }

    //Create the abstract Transporter class so we can use either Road or Sea transporter types when creating a transport
    public abstract class Transporter
    {
        public abstract ITransport CreateTransport();
    }

    public class RoadTransporter : Transporter
    {
        public override Truck CreateTransport()
        {
            return new Truck();
        }
    }

    public class SeaTransporter : Transporter
    {
        public override Boat CreateTransport()
        {
            return new Boat();
        }
    }
}
