using System;
using System.Text.RegularExpressions;
namespace Patikaflix
{

    class Program
    {

        static void Main(string[] args)
        {
               var list = new List<Series>();
            while (true)
            {

                Console.WriteLine("Please enter the series name:");
                string inputName = Console.ReadLine();


                int startDate;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please enter the series Start Date (year):");
                        string inputstartyear = Console.ReadLine();

                        // Attempt to convert the input to an integer
                        if (int.TryParse(inputstartyear, out startDate))
                        {
                            // Validate the year range (assuming it's between 1900 and 2100)
                            if (startDate >= 1900 && startDate <= 2100)
                            {
                                break; // Exit loop if input is valid
                            }
                            else
                            {
                                Console.WriteLine("Year must be between 1900 and 2100. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid year.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle unexpected exceptions
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                }


                SeriesType seriesType;

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please enter the series type (Comedy, Drama, Action, ScienceFiction, Documentary):");
                        string inputSeries = Console.ReadLine();

                        // Attempt to parse the input
                        if (Enum.TryParse(inputSeries, true, out seriesType) && Enum.IsDefined(typeof(SeriesType), seriesType))
                        {
                            // Successfully parsed and valid enum value
                            break;
                        }
                        else
                        {
                            // Invalid enum value
                            Console.WriteLine("Invalid series type. Please enter one of the following: Comedy, Drama, Action, ScienceFiction, Documentary.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle unexpected exceptions
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }

                int publicationDate;

                while (true)
                {

                    try
                    {
                        Console.WriteLine("Please enter the series publicationDate:");
                        string publicationDateInput = Console.ReadLine();

                        // Attempt to parse the publicationDate
                        if (int.TryParse(publicationDateInput, out publicationDate))
                        {
                            if (publicationDate >= 1900 && publicationDate <= 2100)
                            {

                                if (!(publicationDate < startDate))
                                {
                                    break;
                                }
                                else
                                {

                                    Console.WriteLine("Please enter grtater than start date");
                                }
                                }
                            else
                            {
                                Console.WriteLine("Year must be between 1900 and 2100. Please try again.");
                            }
                        }
                           
                           
                        }
                       

                    
                catch (FormatException)
                {
                    Console.WriteLine("Format error: Please enter a valid date.");

                }
                }
                Console.WriteLine("Please enter the series director name :");
                string director = Console.ReadLine();

                Console.WriteLine("Please enter the series published first platform date:");
                string publishedFirstPlatform = Console.ReadLine();
                list.Add(new Series(inputName, startDate, seriesType, publicationDate, director, publishedFirstPlatform));


                Console.WriteLine("Do you want to exit or new input (y/n?)");
                char yesNo= Convert.ToChar(Console.ReadLine());


                if (yesNo == 'n')
                {
                    break;
                }


            }


            // Optionally, print the list to verify the entries
            Console.WriteLine("Series in the list:");
            foreach (var series in list)
            {
                Console.WriteLine($"Series Name: {series.SeriesName}, Start Date: {series.StartDate}, Type: {series.SeriesType}, Publication Date: {series.PublicationDate}, Director: {series.Director}, First Platform: {series.PublishedFirstPlatform}");
            }

     var comedySeriesList = list.Select (c=>new Comedyseries { Director=c.Director,SeriesName=c.SeriesName,SeriesType=c.SeriesType})
                                .OrderBy(c => c.SeriesName)
                                .ThenBy(c => c.Director)
                                .ToList();

            // Output the Comedyseries list
            Console.WriteLine("Comedy Series List:");
            foreach (var comedy in comedySeriesList)
            {
                Console.WriteLine($"Series Name: {comedy.SeriesName}, Series Type: {comedy.SeriesType}, Director: {comedy.Director}");
            }

        }



    }
}
