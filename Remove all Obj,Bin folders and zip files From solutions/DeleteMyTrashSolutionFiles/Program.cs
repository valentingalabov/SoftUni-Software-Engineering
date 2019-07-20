using System;
using System.IO;
using System.Linq;

namespace DeleteAllBinObjAndZipFilesFromMySolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Valio\Desktop\Soft Uni - Software Engineering";

            DeleteTrashItems delete = new DeleteTrashItems();
            delete.DeleteUnusedItems(path);
        }
    }
}
