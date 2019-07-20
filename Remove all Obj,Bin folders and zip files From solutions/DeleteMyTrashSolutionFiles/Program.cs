using System;
using System.IO;
using System.Linq;

namespace DeleteAllBinObjAndZipFilesFromMySolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = @"Add your Github main Folder full path here";

            DeleteTrashItems delete = new DeleteTrashItems();
            delete.DeleteUnusedItems(path);
        }
    }
}
