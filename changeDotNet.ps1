Get-ChildItem . -Recurse -Filter *.*proj |ForEach {
    $content = Get-Content $_.FullName
    $content |ForEach {
        $_.Replace("<TargetFrameworkVersion>v4.5</TargetFrameworkVersion>", "<TargetFrameworkVersion>v4.6</TargetFrameworkVersion>")
    } |Set-Content $_.FullName
}