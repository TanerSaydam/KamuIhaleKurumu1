using System.IO;
using System.Reflection;

namespace VSIXProject1;

[Command(PackageIds.MyCommand)]
internal sealed class MyCommand : BaseCommand<MyCommand>
{
    protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
    {
        var document = await VS.Documents.GetActiveDocumentViewAsync();
        string filePath = document.FilePath.Replace(@"\","/");
        string fileName = document.WindowFrame.Caption;
        string[] paths = filePath.Split('/');
        int length = paths.Length - 1;

        string newPath = "";
        for (int i = 0; i < (paths.Length - 1); i++)
        {
            if(i == 0)
            {
                newPath = paths[i];
            }
            else
            {
                newPath += "/" + paths[i];
            }
           
        }
        newPath += "/IUser.cs";

        //string resourceName = "VSIXProject1.resource.IUser.txt"; // Namespace.resource.FileName
        //using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
        //{
        //    if (stream != null)
        //    {
        //        using (StreamReader reader = new StreamReader(stream))
        //        {
        //            var myInterface = reader.ReadToEnd();
        //            // Diğer kodlar...
        //        }
        //    }
        //    else
        //    {
        //        await VS.MessageBox.ShowWarningAsync("VSIXProject1", "Resource not found");
        //    }
        //}
        string resourcePath = Assembly.GetExecutingAssembly().Location;
        string directory = Path.GetDirectoryName(resourcePath);
        string interfacePath = Path.Combine(directory, "resource", "IUser.txt");

        try
        {
            var myInterface = System.IO.File.ReadAllText(interfacePath);
        }
        catch (Exception ex)
        {
            await VS.MessageBox.ShowWarningAsync("VSIXProject1", ex.Message);
            throw;
        }
        // Dosyanın içeriğini oku


        //        string text = @"
        //                namespace VSIXProject1.Commands;

        //                internal interface IUser
        //                {
        //                }
        //";

        //System.IO.File.WriteAllText(newPath, text);

        await VS.MessageBox.ShowWarningAsync("VSIXProject1", "Button clicked");
    }
}
