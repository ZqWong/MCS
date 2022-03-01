using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cc_clinet
{

    class FileProcess
    {
        public static string GetFileName(string validPath)
        {
            int lastSeperatorIndex = validPath.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
            return validPath.Substring(lastSeperatorIndex + 1);
        }

        public static string GetFileContainer(string validPath)
        {
            int lastSeperatorIndex = validPath.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
            return validPath.Substring(0, lastSeperatorIndex + 1);
        }

        public static string GetDirectoryContainer(string validPath)
        {
            int lastSecondSeperatorIndex = validPath.LastIndexOf(System.IO.Path.DirectorySeparatorChar, validPath.Length - 2);
            return validPath.Substring(0, lastSecondSeperatorIndex + 1);
        }

        public static string GetDirectoryName(string validPath)
        {
            int lastSecondSeperatorIndex = validPath.LastIndexOf(System.IO.Path.DirectorySeparatorChar, validPath.Length - 2);
            return validPath.Substring(lastSecondSeperatorIndex + 1);
        }

        public static bool IsFileOrDirectoryNameValid(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                if (name.Contains(c.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetRenamedFilePath(string validFilePath, string validName)
        {
            return GetFileContainer(validFilePath) + validName;
        }

        public static string GetRenamedDirectoryPath(string validDirectoryPath, string validName)
        {
            return GetDirectoryContainer(validDirectoryPath) + validName + Path.DirectorySeparatorChar;
        }

        public static string GetMovedFilePath(string validFilePath, string validConteinerPath)
        {
            return validConteinerPath + GetFileName(validFilePath);
        }

        public static string GetCopiedFilePath(string validFilePath, string validConteinerPath)
        {
            return GetMovedFilePath(validFilePath, validConteinerPath);
        }

        public static string GetMovedDirectoryPath(string validDirectoryPath, string validConteinerPath)
        {
            return validConteinerPath + GetDirectoryName(validDirectoryPath);
        }

        public static string GetCopiedDirectoryPath(string validDirectoryPath, string validConteinerPath)
        {
            return GetMovedDirectoryPath(validDirectoryPath, validConteinerPath);
        }

        public static bool IsInTheSameDriver(string validContentPath1, string validContentPath2)
        {
            return validContentPath1.Substring(0, 2) == validContentPath2.Substring(0, 2);
        }

        public static void GetFilesLenInFolderRescusively(DirectoryInfo[] dirs, FileInfo[] fileInfos, ref long retLen)
        {
            int nFiles = fileInfos.Length;
            for (int i = 0; i < nFiles; i++)
            {
                retLen += fileInfos[i].Length;
            }

            int nFolders = dirs.Length;
            for (int i = 0; i < nFolders; i++)
            {
                DirectoryInfo[] subDirs = dirs[i].GetDirectories();
                FileInfo[] subFileInfos = dirs[i].GetFiles();
                GetFilesLenInFolderRescusively(subDirs, subFileInfos, ref retLen);
            }
        }

        public static string ConverSizeToLarge(long size)
        {
            var num = 1024.00; //byte

            if (size < num)
                return size + "B";
            if (size < Math.Pow(num, 2))
                return (size / num).ToString("f2") + "K"; //kb
            if (size < Math.Pow(num, 3))
                return (size / Math.Pow(num, 2)).ToString("f2") + "M"; //M
            if (size < Math.Pow(num, 4))
                return (size / Math.Pow(num, 3)).ToString("f2") + "G"; //G


            return (size / Math.Pow(num, 4)).ToString("f2") + "T"; //T
        }
    }
}
