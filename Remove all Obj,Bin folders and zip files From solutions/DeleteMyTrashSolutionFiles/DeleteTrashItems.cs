
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
            foreach (var folder in directoriesOfAllSolutions)
            {
                folder.EnumerateFiles().Where(x => x.Extension == ".zip")
                     .ToList().ForEach(f => f.Delete());

                folder.EnumerateFiles().Where(x => x.Extension == ".rar")
                     .ToList().ForEach(f => f.Delete());
            }


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

            System.Console.WriteLine("All files are deleted!");
        }

    }
}
