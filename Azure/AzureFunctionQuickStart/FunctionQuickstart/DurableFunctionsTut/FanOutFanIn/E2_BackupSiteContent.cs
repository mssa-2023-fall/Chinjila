using FunctionQuickstart;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.DurableTask;
using Microsoft.Azure.WebJobs;
using Microsoft.DurableTask;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Extensions.Logging;

public class FanOutFanIn
{
    private readonly ILogger _logger;
    public FanOutFanIn(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<FanOutFanIn>();
    }

    [Function("E2_BackupSiteContent")]
    public static async Task<long> Run(
    [OrchestrationTrigger]
         TaskOrchestrationContext backupContext, string filepath)
    {
        string rootDirectory = filepath;
        if (string.IsNullOrEmpty(rootDirectory))
        {
            rootDirectory = Directory.GetParent(typeof(FanOutFanIn).Assembly.Location)!.FullName;
        }

        string[] files = await backupContext.CallActivityAsync<string[]>(
            "E2_GetFileList",
            rootDirectory);

        var tasks = new Task<long>[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            tasks[i] = backupContext.CallActivityAsync<long>(
                "E2_CopyFileToBlob",
                files[i]);
        }

        await Task.WhenAll(tasks);

        long totalBytes = tasks.Sum(t => t.Result);
        return totalBytes;
    }


    [FunctionName("E2_GetFileList")]
    public static string[] GetFileList(
    [ActivityTrigger] string rootDirectory,
    ILogger log)
    {
        log.LogInformation($"Searching for files under '{rootDirectory}'...");
        string[] files = Directory.GetFiles(rootDirectory, "*", SearchOption.AllDirectories);
        log.LogInformation($"Found {files.Length} file(s) under {rootDirectory}.");

        return files;
    }


    [FunctionName("E2_CopyFileToBlob")]
    public static async Task<long> CopyFileToBlob(
        [ActivityTrigger] string filePath,
        Binder binder,
        ILogger log)
    {
        long byteCount = new FileInfo(filePath).Length;

        // strip the drive letter prefix and convert to forward slashes
        string blobPath = filePath
            .Substring(Path.GetPathRoot(filePath).Length)
            .Replace('\\', '/');
        string outputLocation = $"backups/{blobPath}";

        log.LogInformation($"Copying '{filePath}' to '{outputLocation}'. Total bytes = {byteCount}.");

        // copy the file contents into a blob
        using (Stream source = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        using (Stream destination = await binder.BindAsync<CloudBlobStream>(
            new BlobAttribute(outputLocation, FileAccess.Write)))
        {
            await source.CopyToAsync(destination);
        }

        return byteCount;
    }
}
