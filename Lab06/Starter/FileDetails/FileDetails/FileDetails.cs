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

            //--.
            string filename = args[0];
            Console.WriteLine("FileName = " + filename);

            //--.
            FileStream stream = new FileStream(filename, FileMode.Open);
            StreamReader reader = new StreamReader(stream);
            
            int size = (int)stream.Length;
            char[] contents = new char[size];
            
            //--.
            for(int i =0; i<size; i++)
            {
                contents[i] = (char) reader.Read();
            }

            reader.Close();

            //--.
            foreach(char ch in contents)
            {
                Console.Write(ch);
            }
        }
    }
}