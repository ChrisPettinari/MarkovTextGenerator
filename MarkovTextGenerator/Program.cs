using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MarkovTextGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chain chain = new Chain();
            String line;
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(@"C:\Users\eahscs\Desktop\spicy.txt"))
            using (var sr = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {


             
                //Pass the file path and file name to the StreamReader constructor
               

                //Read the first line of text


                //Continue to read until you reach end of file
                while ((line = sr.ReadLine()) != null)
                {
                    //write the lie to console window
                    chain.AddString(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                
            }
            
            

            Console.WriteLine("Welcome to Marky Markov's Random Text Generator!");

            Console.WriteLine("Enter some text I can learn from (enter single ! to finish): ");

            foreach(Chain in Chain)
            Console.WriteLine();

            while (true)
            {

                Console.Write("> ");

                line = Console.ReadLine();
                if (line == "!")
                    break;

                chain.AddString(line);  // Let the chain process this string
            }

            // Now let's update all the probabilities with the new data
            chain.UpdateProbabilities();

            // Okay now for the fun part
            Console.WriteLine("Done learning!  Now give me a word and I'll tell you what comes next.");
            Console.Write("> ");

            String word = Console.ReadLine();
            String nextWord = chain.GetNextWord(word);
            Console.WriteLine(nextWord);
            while (nextWord != " ")
            {
                nextWord = chain.GetNextWord(nextWord);
                Console.WriteLine(nextWord);
            }
           
        }
    }
}
