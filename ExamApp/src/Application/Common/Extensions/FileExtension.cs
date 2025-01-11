using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Application.Common.Extensions;

public static class FileExtension
{
    public static async Task<string> SaveFileAsync(this IFormFile file, string folderPath)
    {
        if (file == null) throw new ArgumentNullException(nameof(file));
        if (string.IsNullOrEmpty(folderPath)) throw new ArgumentNullException(nameof(folderPath));

        Directory.CreateDirectory(folderPath);

        string sanitizedFileName = string.Concat(file.FileName.Split(Path.GetInvalidFileNameChars()));
        string uniqueFileName = $"{Guid.NewGuid()}_{sanitizedFileName}";
        string filePath = Path.Combine(folderPath, uniqueFileName);

        try
        {
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }
        catch (Exception ex)
        {
            throw new IOException("An error occurred while saving the file.", ex);
        }

        return uniqueFileName;
    }

    public static bool CheckFileType(this IFormFile file, string fileType) =>
        file.ContentType.StartsWith(fileType, StringComparison.OrdinalIgnoreCase);

    public static bool CheckFileSize(this IFormFile file, int maxFileSizeInMB) =>
        file.Length <= maxFileSizeInMB * 1024 * 1024;

    public static bool CheckFileTypes(this IFormFile file, params string[] allowedFileTypes) =>
        allowedFileTypes.Any(fileType => file.ContentType.StartsWith(fileType, StringComparison.OrdinalIgnoreCase));

    public static void DeleteFile(string folderPath, string fileName)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            string filePath = Path.Combine(folderPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
