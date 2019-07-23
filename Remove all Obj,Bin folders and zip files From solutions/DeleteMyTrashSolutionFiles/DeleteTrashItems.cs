
using System;
using System.IO;
using System.Linq;

namespace DeleteAllBinObjAndZipFilesFromMySolution
{
    public class DeleteTrashItems
    {


        public void DeleteUnusedItems(string path)
        {
            var directoryToOpperate = new DirectoryInfo(path);

            var directoriesOfBinFolders = directoryToOpperate.GetDirectories("bin", SearchOption.AllDirectories);
            var directoriesOfObjFolders = directoryToOpperate.GetDirectories("obj", SearchOption.AllDirectories);

            var directoriesOfAllSolutions = directoryToOpperate.GetDirectories();



            DirectorySearch(path);


            foreach (var itemsInBin in directoriesOfBinFolders)
            {
                itemsInBin.EnumerateDirectories()
                  .ToList().ForEach(d => d.Delete(true));

                itemsInBin.EnumerateFiles()
                    .ToList().ForEach(f => f.Delete());



                itemsInBin.Delete();
            }
            foreach (var itemsInObj in directoriesOfObjFolders)
            {
                itemsInObj.EnumerateDirectories()
                    .ToList().ForEach(d => d.Delete(true));
                itemsInObj.EnumerateFiles()
                    .ToList().ForEach(f => f.Delete());



                itemsInObj.Delete();

            }

            Console.WriteLine("All files are deleted!");

        }

        //find all files in directory tree with extension .zip

        public static void DirectorySearch(string root, bool isRootItrated = false)
        {
            if (!isRootItrated)
            {
                var rootDirectoryFiles = Directory.GetFiles(root);
                foreach (var file in rootDirectoryFiles)
                {
                    if (file.EndsWith(".zip"))
                    {
                        File.Delete(file);
                    }
                }
            }

            var subDirectories = Directory.GetDirectories(root);

            if (subDirectories?.Any() == true)
            {
                foreach (var directory in subDirectories)
                {
                    var files = Directory.GetFiles(directory);
                    foreach (var file in files)
                    {
                        if (file.EndsWith(".zip"))
                        {
                            File.Delete(file);
                        }
                    }
                    DirectorySearch(directory, true);
                }
            }
        }
    }
}