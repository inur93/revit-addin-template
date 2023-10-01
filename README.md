# revit-addin-template
A basic template for creating Revit Addins

# Install
Run the below script to install the template.
Alternatively clone the repository and run the `InstallTemplate.ps1` script.  
The below script downloads, installs the template and removes the temporary files after it is installed.

```powershell
$Url = "https://github.com/inur93/revit-addin-template/archive/refs/heads/v/2024.zip"
$CurDir = Get-Location
$TempDir = Join-Path ([System.IO.Path]::GetTempPath()) "RevitAddinTemplate"
$TemplateContainerDir = Join-Path $env:UserProfile "Documents\Visual Studio 2022\Templates\ProjectTemplates\Visual C#"
$TemplateDir = Join-Path $TemplateContainerDir "revit-addin-template-v-2024"
$ArchiveFile = Join-Path $TempDir "ProjectArchive.zip"

if(Test-Path $TempDir){
  Remove-Item $TempDir
}
New-Item -ItemType Directory -Path $TempDir

if(Test-Path $TemplateDir){
  Remove-Item $TemplateDir
}

Invoke-WebRequest $Url -OutFile $ArchiveFile
Expand-Archive $ArchiveFile $TemplateContainerDir
CD $TemplateDir
dotnet new install RevitAddinTemplate --force
CD $CurDir
```

# Development

## Installer properties
To pass default properties from installer to a configuration program see available properties here https://learn.microsoft.com/en-us/windows/win32/msi/property-reference?redirectedfrom=MSDN
