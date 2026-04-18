
namespace winFormTestSauron.Core
{
    public class FileOperationsManager
    {
        // Cette Class sert a gérer toute les opérations sur les dossier/Fichiers
        public string[] ShowDisk()
        {
            return Directory.GetLogicalDrives();
        }

        
        public DirectoryInfo[] AddDirs(string path)
        {
            
            DirectoryInfo info = new DirectoryInfo(path);
            DirectoryInfo[] dir = { };

            try
            {
                if (info != null)
                {
                    dir = info.GetDirectories();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // On ignore le dossier si l'accès est refusé
                dir = new DirectoryInfo[0];
            }
            catch (Exception ex)
            {
                // Pour gérer d'autres erreurs éventuelles
                Console.WriteLine("Erreur : " + ex.Message);
            }
            return dir;
        }

        public FileInfo[] ShowFileNames(DirectoryInfo _info)
        {
            DirectoryInfo info = _info;
            FileInfo[] _Files = {};
            
            if (info.Exists)
                {
                    _Files = info.GetFiles();
                }

            return _Files;
        }

        public string FileSizeCalculator(long length)
        {
            
            long sizeInKb = length / 1024;
            double modularsize;

            if (sizeInKb <= 1000)
            {
                modularsize = sizeInKb;
                return modularsize.ToString() + " KB";
            }
            else if (sizeInKb >= 1000)
            {
                modularsize = sizeInKb / 1000;
                return modularsize.ToString() + " MB";
            }
            else if (sizeInKb >= 1000000) 
            {
                modularsize = sizeInKb / 1000000;
                return modularsize.ToString() + " GB";
            }
            else 
            {
                return length.ToString() + " B";
            }
        }

        public void OpenFile()
        {
            
        }
    }
}