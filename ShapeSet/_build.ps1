Remove-Item -Force -Recurse .\wwwroot\
New-Item -Type Directory -Path .\wwwroot\

& sassc -m "ShapeSet.scss" ".\wwwroot\ShapeSet.css"
if (-not$?)
{
    exit 2
}

foreach ($override in $( Get-ChildItem ".\Overrides\" -Filter *.scss ))
{
    Write-Output "Building stylesheet: $( $override.Name )"
    & sassc -m ".\Overrides\$( $override.BaseName ).scss" ".\wwwroot\$( $override.BaseName ).css"
    
    if (-not$?)
    {
        exit 2
    }
}
