using Autodesk.RevitAddIns;
using System;
using System.IO;

namespace RevitAddinTemplate.Configuration
{
    internal class ManifestFactory
    {
        public void Create(string directory)
        {
            //create a new addin manifest
            RevitAddInManifest manifest = new RevitAddInManifest();

            //create an external application
            RevitAddInApplication application = new RevitAddInApplication(
                "RevitAddinTemplate",
                $"{directory}\\RevitAddinTemplate.dll",
               new Guid("a90f714d-3bcf-43df-ab4e-823a4b42e1a1"),
                "RevitAddinTemplate.App",
                "Eivind Vørmadal");

            manifest.AddInApplications.Add(application);

            //save manifest to a file
            RevitProduct revitProduct = RevitProductUtility.GetAllInstalledRevitProducts()[0];
            var targetDir = Path.Combine(revitProduct.AllUsersAddInFolder, "RevitAddinTemplate.addin");
            manifest.SaveAs(targetDir);
        }
    }
}
