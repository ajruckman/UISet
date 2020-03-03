Remove-Item -Force -Recurse .\wwwroot\css\
New-Item -Type Directory -Path .\wwwroot\css\

foreach ($theme in $(Get-ChildItem "..\ColorSet\Themes\" -Directory))
{
    Write-Output "Building stylesheet: $($theme.FullName)"
    & sassc -m "Style.$($theme.Name).scss" ".\wwwroot\css\Style.$($theme.Name).css"

    if (-not $?)
    {
        exit 2
    }
}
