using System;

namespace Auction
{
    class Program
    {
        static void Main(string[] args)
        {
            Naveen naveen = new Naveen();
            Sasank sasank = new Sasank();
            Varun varun = new Varun();
            Venky venky = new Venky();
            Vignesh vignesh = new Vignesh();
            Yash yash = new Yash();
            Unsold unsold = new Unsold();
            Auction a = new Auction(vignesh, naveen, yash, sasank, varun, venky, unsold);


        }
    }
}
