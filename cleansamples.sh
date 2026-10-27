#!/usr/bin/env bash
set -euo pipefail

ROOT_PATH="$(pwd)"
SAMPLES_PATH="$ROOT_PATH/samples"

if [ ! -d "$SAMPLES_PATH" ]; then
  echo "Error: samples directory not found:"
  echo "$SAMPLES_PATH"
  echo
  echo "Run this script from the repository root."
  exit 1
fi

echo "Searching for all 'bin' and 'obj' folders under:"
echo "$SAMPLES_PATH"
echo

# Find only inside samples
FOLDERS=$(find "$SAMPLES_PATH" -type d \( -name bin -o -name obj \))

if [ -z "$FOLDERS" ]; then
  echo "No 'bin' or 'obj' folders found under samples."
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
echo "Samples cleanup complete."
