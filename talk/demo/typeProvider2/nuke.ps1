$executingDir = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

Remove-Item "$executingDir/bin" -Recurse
Remove-Item "$executingDir/obj" -Recurse