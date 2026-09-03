$ROOT_PATH = Get-Location
$SAMPLES_PATH = Join-Path $ROOT_PATH "samples"

if (-not (Test-Path -LiteralPath $SAMPLES_PATH -PathType Container)) {
    Write-Host "Error: samples directory not found:"
    Write-Host $SAMPLES_PATH
    Write-Host ""
    Write-Host "Run this script from the repository root."
    exit 1
}

Write-Host "Searching for all 'bin' and 'obj' folders under:"
Write-Host $SAMPLES_PATH
Write-Host ""

# Find only inside samples
$folders = Get-ChildItem -Path $SAMPLES_PATH -Directory -Recurse -Force -ErrorAction SilentlyContinue |
    Where-Object { $_.Name -eq "bin" -or $_.Name -eq "obj" }

if (-not $folders) {
    Write-Host "No 'bin' or 'obj' folders found under samples."
    exit 0
}

$count = $folders.Count

Write-Host "Found $count folders to delete."
Write-Host ""

# Delete each folder
foreach ($folder in $folders) {
    Write-Host "Deleting folder: $($folder.FullName)"

    try {
        Remove-Item -LiteralPath $folder.FullName -Recurse -Force -ErrorAction Stop
        Write-Host "Deleted: $($folder.FullName)"
    }
    catch {
        Write-Warning "Failed to delete $($folder.FullName): $($_.Exception.Message)"
    }
}

Write-Host ""
Write-Host "Samples cleanup complete."
