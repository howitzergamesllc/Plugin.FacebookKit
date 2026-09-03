#!/usr/bin/env bash
set -euo pipefail

ROOT_PATH="$(pwd)"

echo "Searching for all 'bin' and 'obj' folders under $ROOT_PATH ..."
echo

# Find bin and obj directories
FOLDERS=$(find "$ROOT_PATH" -type d \( -name bin -o -name obj \))

if [ -z "$FOLDERS" ]; then
  echo "No 'bin' or 'obj' folders found."
  exit 0
fi

COUNT=$(printf "%s\n" "$FOLDERS" | wc -l | tr -d ' ')
echo "Found $COUNT folders to delete."
echo

# Delete each folder
printf "%s\n" "$FOLDERS" | while IFS= read -r folder; do
  echo "Deleting folder: $folder"
  if rm -rf "$folder"; then
    echo "Deleted: $folder"
  else
    echo "Warning: Failed to delete $folder" >&2
  fi
done

echo
echo "Cleanup complete."
