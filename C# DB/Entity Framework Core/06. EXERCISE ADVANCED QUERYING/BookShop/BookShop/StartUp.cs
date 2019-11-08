namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //string input = Console.ReadLine().ToLower();

                //int number = int.Parse(Console.ReadLine());

               var result= RemoveBooks(db);

                Console.WriteLine(result);


            }
        }

        //1. Age Restriction

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            int ageRestriction = AgeRestriction.Minor.ToString().ToLower().Equals(command.ToLower()) ? 0 :
               AgeRestriction.Teen.ToString().ToLower().Equals(command.ToLower()) ? 1 :
               AgeRestriction.Adult.ToString().ToLower().Equals(command.ToLower()) ? 2 : 3;


            var books = context
                .Books
                .Where(b => (int)b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    b.Title

                })
                .ToList();

            foreach (var item in books)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString();
        }


        //2. Golden Books

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => (int)b.EditionType == 2 && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title

                })
                .ToList();


            foreach (var item in books)
            {
                sb.AppendLine(item.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //3. Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                }).ToList();


            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //4. Not Released In

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title

                });

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();

        }

        //5. Book Titles by Category

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] categories = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(c => c.ToLower()).ToArray();

            var booksTitles = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (var b in booksTitles)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        //6. Released Before Date

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < releaseDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                });

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        //7. Author Search

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToList();

            foreach (var a in authors)
            {
                sb.AppendLine(a.FullName);
            }

            return sb.ToString().TrimEnd();

        }

        //8. Book Search

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        //9. Book Search by Author

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksAndAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    Author = $"{b.Author.FirstName} {b.Author.LastName}"

                })
                .ToList();

            foreach (var b in booksAndAuthors)
            {
                sb.AppendLine($"{b.Title} ({b.Author})");
            }

            return sb.ToString().TrimEnd();

        }

        //10. Count Books

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var numberOfbooks = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return numberOfbooks;
        }

        //11.	Total Book Copies

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors =
                context
                .Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    BookCopies = a.Books.Sum(b => b.Copies)

                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();


            foreach (var a in authors)
            {
                sb.AppendLine($"{a.Name} - {a.BookCopies}");
            }

            return sb.ToString().TrimEnd();

        }

        //12. Profit by Category

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var profitsByCategory = context.Categories
                            .Select(c => new
                            {
                                c.Name,
                                Profit = c.CategoryBooks.Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
                            })
                            .OrderByDescending(c => c.Profit)
                            .ThenBy(c => c.Name)
                            .ToList();

            foreach (var p in profitsByCategory)
            {
                sb.AppendLine($"{p.Name} ${p.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Most Recent Books

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoryAndMostRecentBooks = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryRecentBooks = c.CategoryBooks
                                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                                            .Take(3)
                                            .Select(cb => new
                                            {
                                                BookTitle = cb.Book.Title,
                                                BookRelease = cb.Book.ReleaseDate.Value.Year
                                            })
                                            .ToList()

                })
                .OrderBy(c => c.CategoryName);


            foreach (var c in categoryAndMostRecentBooks)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.CategoryRecentBooks)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.BookRelease})");
                }
            }

            return sb.ToString().TrimEnd();
        }


        //14. Increase Prices

        public static void IncreasePrices(BookShopContext context)
        {
            var books =
                context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var b in books)
            {
                b.Price += 5;
            }

        }

        //15. Remove Books

        public static int RemoveBooks(BookShopContext context)
        {
            var booksWithLessThan4200Coipies = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int countOfDeletes = 0;

            foreach (var b in booksWithLessThan4200Coipies)
            {
                context.Remove(b);
                countOfDeletes++;
            }

            context.SaveChanges();

            return countOfDeletes;




        }
    }
}
