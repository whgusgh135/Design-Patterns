namespace SOLID_Principle
{
    // INTERFACE SEGREGATION PRINCIPLE
    // Clients should not be forced to depend upon
    // interfaces that they do not use.
    
    // In summary, if interface gets too big, break it up to smaller interfaces
    
    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Print(Document d)
        {
            // No problem!!
        }

        public void Scan(Document d)
        {
            // No problem!!
        }

        public void Fax(Document d)
        {
            // No problem!!
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Print(Document d)
        {
            // No problem!!
        }

        public void Scan(Document d)
        {
            // Does not need this method :(
        }

        public void Fax(Document d)
        {
            // Does not need this method :(
        }
    }

    // Solution? Make smaller interfaces!!
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            // No problem!!
        }

        public void Scan(Document d)
        {
            // No problem!!
        }
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        } // decorator
    }
}