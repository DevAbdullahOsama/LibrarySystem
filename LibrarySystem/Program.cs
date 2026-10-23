using LibrarySystem.Helper;
using LibrarySystem.Models;
using LibrarySystem.Services;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayService displayService = new DisplayService();
            LibraryBranch branch = DataSeeder.Seed();
            LibraryService libraryService = new LibraryService(displayService, branch);
            bool running = true;
            while (running)
            {
                try
                {
                    ConsoleHelper.ShowMenu();
                    string? choice = Console.ReadLine()?.Trim();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1": displayService.ShowBranchInformation(branch); break;
                        case "2": displayService.ShowAllUsers(branch); break;
                        case "3": displayService.ShowAvailableBooks(branch); break;
                        case "4": displayService.ShowAllBooks(branch); break;
                        case "5": libraryService.HandleBookBorrowing(); break;
                        case "6": libraryService.HandleBookReturning(); break;
                        case "7": libraryService.HandleHistoryViewing(); break;
                        case "8": libraryService.HandleMemberRegister(); break;
                        case "0":
                            Console.WriteLine("  Goodbye!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("  Invalid option. Try again.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }

                Console.WriteLine("\n  Press Enter to continue...");
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
