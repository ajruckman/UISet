function Clean-DotNETProject
{
    Get-ChildItem .\ -include bin, obj -Recurse | foreach ($_) {
        Write-Output "Remove: $( $_.FullName )"
        Remove-Item $_.FullName -Force -Recurse
    }
}

Clean-DotNETProject

cd .\ColorSet\
dotnet run
.\_build.ps1
cd ..

cd .\ShapeSet\
.\_build.ps1
cd ..

dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg

if (!(Test-Path .\_published\))
{
    md .\_published\
}

Get-ChildItem -Directory | foreach {
    if (Test-Path "$( $_.FullName )\bin")
    {
        Get-ChildItem "$($_.FullName)\bin\" -Depth 1  | ? { ($_.FullName -like "*.nupkg") -or ($_.FullName -like "*.snupkg") } | foreach {
            Write-Output "Copying package: $( $_.Name )"
            Copy-Item $_.FullName .\_published\
        }
    }
}

Remove-Item -ErrorAction Ignore -Force -Recurse $HOME\.nuget\packages\uiset.colorset\
Remove-Item -ErrorAction Ignore -Force -Recurse $HOME\.nuget\packages\uiset.fontset\
Remove-Item -ErrorAction Ignore -Force -Recurse $HOME\.nuget\packages\uiset.shapeset\
