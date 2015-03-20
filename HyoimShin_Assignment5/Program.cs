/********************************************************
 * Hyoim Shin (300802252)
 * March 19, 2015
 * Assignment5 : File I/O - Exception
 * Revision History : 
 * - added MainMenu() method
 * - added CreateGradeTxt() method
 * - added DisplayGrade() method
 * ******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HyoimShin_Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
            WaitForKey();
        }

        public static void MainMenu()
        {
            string pathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            const char DELIM = ',';

            int selection = 0;

            while (selection != 2)
            {
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.WriteLine("+                         +");
                Console.WriteLine("+    1. Display Grades    +");
                Console.WriteLine("+    2. Exit              +");
                Console.WriteLine("+                         +");
                Console.WriteLine("+++++++++++++++++++++++++++");
                Console.Write("Please make your selection: ");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    selection = 0;
                }
                switch (selection)
                {
                    case 1:
                        CreateGradeTxt(pathName, DELIM);
                        DisplayGrades(pathName, DELIM);
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Incorrect entry. Please try again....\n");
                        break;
                }
            }
        }

        // Create grade.txt file
        private static void CreateGradeTxt(string pathName, char DELIM)
        {
            string fileName = "grade.txt";
            string[] firstName = {"Jones", "Johnson", "Sarah"};
            string[] lastName = {"Bob","Sarah","Sam"};
            string[] studentIndex = {"1", "2", "3"};
            string[] className = {"Introduction to Computer Science", "Data Structures", "Data Structures" };
            string[] classGrade = {"A-", "B+", "C"};
 
            try
            {
                FileStream outFile = new FileStream(pathName + "\\" + fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine(firstName[i] + DELIM + lastName[i] + DELIM + studentIndex[i] + DELIM + className[i] + DELIM + classGrade[i]);
                }
                writer.Close();
                outFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error : {0}", error.Message);
            }
        }

        // Display grade
        public static void DisplayGrades(string pathName, char DELIM)
        {
            string fileName;
            string[] fields;
            string fileData = "";
            string firstName;
            string lastName;
            string studentIndex;
            string className;
            string classGrade;

            Console.Write("Please enter a File name : ");
            fileName = Console.ReadLine();
            Console.WriteLine();

            try
            {
                FileStream inFile = new FileStream(pathName + "\\" + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                fileData = reader.ReadLine();

                while (fileData != null)
                {
                    fields = fileData.Split(DELIM);
                    firstName = fields[0];
                    lastName = fields[1];
                    studentIndex = fields[2];
                    className = fields[3];
                    classGrade = fields[4];

                    Console.WriteLine("{0}, {1}: {2} {3}, {4}", firstName, lastName, studentIndex, className, classGrade);
                    fileData = reader.ReadLine();
                }
                Console.WriteLine();
                reader.Close();
                inFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("No such file");
                Console.WriteLine(error.Message);
                Console.WriteLine();
            }
        }
        // UTILITY METHOD ++++++++++++++++++++++++++++++++++++++
        public static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.WriteLine("Press any key to exit....");
            Console.WriteLine("+++++++++++++++++++++++++++");
            Console.ReadKey();
            Console.Clear();
        }
    }
}