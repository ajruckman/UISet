Remove-Item -Force -Recurse .\wwwroot\
New-Item -Type Directory -Path .\wwwroot\

& sassc -m "ShapeSet.scss" ".\wwwroot\ShapeSet.css"

if (-not $?)
{
    exit 2
}

& sassc -m ".\Overrides\BlazorErrorUI.scss" ".\wwwroot\BlazorErrorUI.css"
