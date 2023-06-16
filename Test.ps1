param([int] $Number)

dotnet new revitaddin -n "TestProject$Number" -o "TestProject$Number" --RevitAssemblies "..\testAssemblies" --RevitVersion "Revit 2024"