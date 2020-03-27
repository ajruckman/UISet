Remove-Item -Force -Recurse .\wwwroot\
New-Item -Type Directory -Path .\wwwroot\

& sassc -m "ShapeSet.scss" ".\wwwroot\ShapeSet.css"

if (-not $?)
{
    exit 2
}
