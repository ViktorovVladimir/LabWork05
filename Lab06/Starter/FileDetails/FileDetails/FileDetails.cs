namespace FileDetails
{
    using System;

    //--.
    public class Test
    {
        static void Main(string [] args)
        {
            //--. Get input numbers
            Console.WriteLine("Длина args: "+args.Length);

            //--.
            foreach (string arg in args) 
            {
                Console.WriteLine(arg);
            }

            string filename = args[0];
            Console.WriteLine("FileName = " + filename);

        }
    }
}