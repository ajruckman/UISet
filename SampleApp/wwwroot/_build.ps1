Get-ChildItem -Recurse -Filter *.css | Remove-Item
Get-ChildItem -Recurse -Filter *.css.map | Remove-Item

foreach ($theme in @("Light", "Dark")) 
{
    Write-Output "Building stylesheet: $($theme)"
    & sassc -m "Style.$($theme).scss" "Style.$($theme).css"

    if (-not $?)
    {
        exit 2
    }
}
