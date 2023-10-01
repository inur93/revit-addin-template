using Autodesk.RevitAddIns;
using System;
using System.IO;
using System.Linq;

namespace RevitAddinTemplate.Configuration
{
    internal class ManifestFactory
    {
        public void Create(string directory)
        {
            //create a new addin manifest
            RevitAddInManifest manifest = new RevitAddInManifest();

            var dllRef = Path.Combine(directory, "RevitAddinTemplate.dll");
            //create an external application
            RevitAddInApplication application = new RevitAddInApplication(
                "RevitAddinTemplate",
                dllRef,
               new Guid("a90f714d-3bcf-43df-ab4e-823a4b42e1a1"),
                "RevitAddinTemplate.App",
                "Eivind Vørmadal");

            manifest.AddInApplications.Add(application);
            var products = RevitProductUtility.GetAllInstalledRevitProducts();

            if (!products.Any())
            {
                throw new Exception("Revit is not installed");
            }

            //TODO find a way to handle multiple versions of Revit
            var product = products.Where(x => (int)x.Version == 14).FirstOrDefault();

            if (product == null)
            {
                throw new Exception("Version 2024 is not installed");
            }

            //save manifest to a file
            var targetDir = Path.Combine(product.CurrentUserAddInFolder, "RevitAddinTemplate.addin");
            manifest.SaveAs(targetDir);
        }
    }
}
