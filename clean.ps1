$ROOT_PATH = Get-Location

Write-Host "Searching for all 'bin' and 'obj' folders under $ROOT_PATH ..."
Write-Host ""

# Find bin and obj directories
$folders = Get-ChildItem -Path $ROOT_PATH -Directory -Recurse -Force -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -eq "bin" -or $_.Name -eq "obj" }

if (-not $folders) {
    Write-Host "No 'bin' or 'obj' folders found."
    exit 0
}

$count = $folders.Count

Write-Host "Found $count folders to delete."
Write-Host ""

# Delete each folder
foreach ($folder in $folders) {
    Write-Host "Deleting folder: $($folder.FullName)"

    try {
        Remove-Item -Path $folder.FullName -Recurse -Force -ErrorAction Stop
        Write-Host "Deleted: $($folder.FullName)"
    }
    catch {
        Write-Warning "Failed to delete $($folder.FullName): $($_.Exception.Message)"
    }
}

Write-Host ""
Write-Host "Cleanup complete."
