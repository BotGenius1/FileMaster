using System;
using System.IO;
class FileMaster
{
    static void Main(string[] args)
    {
        FileMaster fileMaster = new FileMaster();
        while (true)
        {
            Console.WriteLine("1. Create Directory\n" +
            "2. Delete Directory\n" +
            "3. Create File\n" +
            "4. Delete File\n" +
            "5. View all files\n" +
            "6. Exit Program\n" +
            "Input: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    fileMaster.CreateDirectory();
                    break;

                case "2":
                    fileMaster.DeleteDirectory();
                    break;

                case "3":
                    fileMaster.CreateFile();
                    break;

                case "4":
                    fileMaster.DeleteFile();
                    break;

                case "5":
                    fileMaster.ViewDirectoryFiles();
                    break;

                case "6":
                    break;
            }
        }
    }
    // Create a directory
    void CreateDirectory()
    {
        Console.WriteLine("Enter the path of the directory you want to create:\n");
        string path = Console.ReadLine();
        try
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("That directory path already exist!\n");
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine($"Directory path {path} has been created\n");
            }
        }
        catch(IOException e) 
        {
            Console.WriteLine("The path you provided is a file, not a directory\n");
        }
        catch(UnauthorizedAccessException e)
        {
            Console.WriteLine("You do not have the required permission\n");
        }
        catch(ArgumentException e )
        {
            Console.WriteLine("Path is null, you need to actually input a path to create a directory\n");
        }
        
    } 
    // Delete Directory 
    void DeleteDirectory()
    {
        Console.WriteLine("Enter the path of the directory that you want to delete\n");
        string pathToDelete = Console.ReadLine();
        try
        {
            if (!Directory.Exists(pathToDelete))
            {
                Console.WriteLine("That directory does not exist\n");
            }
            else
            {
                Directory.Delete(pathToDelete, true);
                Console.WriteLine($"The directory path {pathToDelete} and all files inside have been deleted\n");
            }
        }
        catch(IOException e)
        {
            Console.WriteLine("There are several possible issues that occured, you are either working in the directory you are trying to delete\n" +
                "The directory contains a read only file, or the directory is being used by another process\n");
        }
        catch(UnauthorizedAccessException e)
        {
            Console.WriteLine("You do not have the authorization to delete that directory\n");
        }
        catch(ArgumentNullException e)
        {
            Console.WriteLine("This error occured because the directory path is null, you must enter a path to delete\n");
        }
    }

    // Create a file
    void CreateFile()
    {
        Console.WriteLine("Enter the name of the file that you want to create\n");
        string file = Console.ReadLine();
        if (File.Exists(file))
        {
            Console.Write("That file already exist\n");
        }
        else
        {
            string currentDir = Directory.GetCurrentDirectory();
            File.Create($"{file}.txt");
            Console.WriteLine($"File with name {file}.txt has been created in {currentDir}\n");
        }
    }

    // Delete a file
    void DeleteFile()
    {
        Console.WriteLine("Enter the name of the file that you want to delete\n");
        string fileToDelete = Console.ReadLine();
        if (!File.Exists($"{fileToDelete}.txt"))
        {
            Console.WriteLine("That file already does not exist\n");
        }
        else
        {
            try
            {
                string currentDir = Directory.GetCurrentDirectory();
                File.Delete($"{fileToDelete}.txt");
                Console.WriteLine($"File with name {fileToDelete} in directory {currentDir} has been deleted\n");
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occured, try again\n");
            }
        }
    }

    // view all files in the directory
    void ViewDirectoryFiles()
    {
        Console.WriteLine("Enter the directory for the files that you want to view\n");
        string dir = Console.ReadLine();
        if (Directory.Exists(dir))
        {
            string[] files = Directory.GetFiles(dir);
            for (int i = 1; i < files.Length; i++)
            {
                Console.WriteLine($"{i}. {files[i]}\n");
            }
        }
        else
        {
            Console.WriteLine("Directory does not exist\n");
        }
    }

    
}