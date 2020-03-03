Remove-Item -Force -Recurse .\wwwroot\
New-Item -Type Directory -Path .\wwwroot\css\

foreach ($theme in $(Get-ChildItem ".\Themes\" -Directory))
{
    Write-Output "Building globals: $($theme.FullName)"
    & sassc -m ".\Themes\$($theme.Name)\globals.scss" ".\wwwroot\css\Globals.$($theme.Name).css"

    if (-not $?)
    {
        exit 2
    }
}
