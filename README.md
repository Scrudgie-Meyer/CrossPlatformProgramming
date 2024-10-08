# CrossPlatformLabs

## Installation
1. Clone project
2. Install **dotnet sdk**
3. Build project

## Usage

### Build
```bash
dotnet build Build.proj -p:Solution=Lab1 -t:Build
```

### Test
```bash
dotnet build Build.proj -t:Test
```

### Run
```bash
dotnet build Build.proj -p:Solution=Lab1 -t:Run
```