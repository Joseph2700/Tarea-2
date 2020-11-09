using System;
using System.IO;
using System.Collections;

namespace Tarea_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string studentpath = (@"C:\Users\dell\Desktop\Tarea 2\Students.txt");
            const string topicpath = (@"C:\Users\dell\Desktop\Tarea 2\Topics.txt");

            Console.WriteLine("Enter the number of groups");
            int groups = Convert.ToInt32(Console.ReadLine());
            string[] students = File.ReadAllLines(studentpath);
            string[] topics = File.ReadAllLines(topicpath);

            Randomize(students);
            Randomize(topics);

            int studentpergroup = students.Length/ groups;
            int topicpergroup = topics.Length/ groups;

            ArrayList studentlist = new ArrayList(students);
            ArrayList topiclist = new ArrayList(topics);
            if(students.Length != 0 && topics.Length >= groups)
            {
                for(int i = 1; i <= groups; i++)
                {
                    Console.WriteLine($"Group{i}: ");
                    {
                        for(int j = 0; j < studentpergroup; j++)
                        {
                            Console.WriteLine($"\t{j + 1} - {studentlist[0]}");
                            studentlist.RemoveAt(0);
                        }

                        Console.WriteLine("Topics: ");
                        for(int n = 0; n < topicpergroup; n++)
                        {
                            Console.WriteLine($"\t{topiclist[0]}");
                            topiclist.RemoveAt(0);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Student or Topics not enough");
            }
        }

        public static string[] Randomize(string [] array)
        {
            Random rnd = new Random();
            for(int i = array.Length - 1; i > 0; i--)
            {
                int swapIndex = rnd.Next(i + 1);
                string temp = array[i];
                array[i] = array[swapIndex];
                array[swapIndex] = temp;
            }
            return array;
        }
    }
}
