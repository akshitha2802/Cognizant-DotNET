# install_and_push_git.ps1
# Finds Git, adds it to the current user's PATH (if needed), verifies git, initializes repo, and optionally pushes to a remote.

Write-Host "Starting Git helper script..." -ForegroundColor Cyan

$commonPaths = @(
    "C:\Program Files\Git\cmd\git.exe",
    "C:\Program Files\Git\bin\git.exe",
    "$env:LOCALAPPDATA\Programs\Git\cmd\git.exe",
    "$env:ProgramFiles\Git\cmd\git.exe"
)

$gitExe = $null
$gitExe = $commonPaths | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $gitExe) {
    try {
        $gitExe = Get-ChildItem -Path "C:\Program Files","C:\Program Files (x86)","$env:LOCALAPPDATA" -Filter git.exe -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
        if ($gitExe) { $gitExe = $gitExe.FullName }
    } catch {
        # ignore
    }
}

if (-not $gitExe) {
    Write-Host "Git executable not found. Please install Git for Windows first: https://git-scm.com/download/win" -ForegroundColor Red
    exit 1
}

$gitDir = Split-Path $gitExe -Parent
Write-Host "Found git at: $gitExe" -ForegroundColor Green

# Add to USER PATH if missing
$userPath = [Environment]::GetEnvironmentVariable("Path","User")
if ($userPath -notlike "*${gitDir}*") {
    $newPath = $userPath + ";" + $gitDir
    [Environment]::SetEnvironmentVariable("Path", $newPath, "User")
    Write-Host "Added $gitDir to user PATH. Restart PowerShell (close & reopen) to pick up changes." -ForegroundColor Green
} else {
    Write-Host "Git directory already in user PATH." -ForegroundColor Yellow
}

# Verify git
Write-Host "Verifying git..." -ForegroundColor Cyan
& "$gitExe" --version
if ($LASTEXITCODE -ne 0) {
    Write-Host "git verification failed. Ensure Git is properly installed." -ForegroundColor Red
    exit 1
}

# Ensure user.name and user.email are configured
try {
    $currentName = git config --global user.name 2>$null
} catch { $currentName = "" }
if (-not $currentName) {
    $name = Read-Host "Enter Git user.name (will be saved globally)"
    if ($name) { git config --global user.name "$name" }
}

try {
    $currentEmail = git config --global user.email 2>$null
} catch { $currentEmail = "" }
if (-not $currentEmail) {
    $email = Read-Host "Enter Git user.email (will be saved globally)"
    if ($email) { git config --global user.email "$email" }
}

# Repo directory
$repoDirInput = Read-Host "Repository folder (press Enter for current workspace folder)"
if (-not $repoDirInput) { $repoDir = Get-Location } else { $repoDir = Resolve-Path $repoDirInput }
Set-Location $repoDir
Write-Host "Working in: $repoDir" -ForegroundColor Cyan

# Initialize repo if needed
if (-not (Test-Path ".git")) {
    git init
    git add -A
    # If there is nothing to commit, skip
    $status = git status --porcelain
    if ($status) {
        git commit -m "Initial commit"
    } else {
        Write-Host "Nothing to commit (no changes)." -ForegroundColor Yellow
    }
} else {
    Write-Host "Repository already initialized (found .git)." -ForegroundColor Yellow
}

# Remote and push
$remote = Read-Host "Remote URL (HTTPS), e.g. https://github.com/username/repo.git (leave empty to skip push)"
if ($remote) {
    git remote remove origin 2>$null
    git remote add origin $remote
    git branch -M main 2>$null
    Write-Host "Attempting to push to remote 'origin' on branch 'main'..." -ForegroundColor Cyan
    git push -u origin main
    if ($LASTEXITCODE -ne 0) {
        Write-Host "Push failed. You may need to authenticate. Options:" -ForegroundColor Yellow
        Write-Host "  1) Use Git Credential Manager (recommended)." -ForegroundColor Yellow
        Write-Host "  2) Create a Personal Access Token (PAT) and use it when prompted." -ForegroundColor Yellow
        Write-Host "  3) Use an authenticated remote URL (not recommended to embed token in plain text)." -ForegroundColor Yellow
        Write-Host "Example authenticated URL format (avoid storing this):" -ForegroundColor Yellow
        Write-Host "  https://<username>:<PAT>@github.com/<username>/<repo>.git" -ForegroundColor Yellow
    } else {
        Write-Host "Push succeeded." -ForegroundColor Green
    }
}

Write-Host "Script finished." -ForegroundColor Green
