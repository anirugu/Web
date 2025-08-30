# Web

ASP.NET Core Blazor application with API controllers and Docker support.

## Features

- **Blazor Server**: Interactive web UI with server-side rendering
- **API Controllers**: RESTful API endpoints for integration
- **Docker Support**: Containerized deployment ready
- **CI/CD**: Automated Docker image building and publishing

## API Endpoints

- `GET /api/values` - Get list of values
- `GET /api/values/{id}` - Get specific value by ID
- `POST /api/values` - Create new value
- `PUT /api/values/{id}` - Update existing value
- `DELETE /api/values/{id}` - Delete value

- `GET /api/weather` - Get weather forecast
- `GET /api/weather/{id}` - Get specific weather forecast
- `POST /api/weather` - Create weather forecast

## Running Locally

### Prerequisites
- .NET 8.0 SDK
- Docker (optional)

### Development
```bash
dotnet run --project src/Web/Web.csproj
```

### Docker
```bash
# Build image
docker build -t web-app .

# Run container
docker run -d -p 8080:8080 --name web-container web-app

# Test API
curl http://localhost:8080/api/values
```

## CI/CD Pipeline

The application automatically builds and publishes Docker images to GitHub Container Registry on every commit to `main` or `develop` branches.

### Image Tags
- `latest` - Latest build from main branch
- `main-<sha>` - Specific commit from main branch  
- `develop-<sha>` - Specific commit from develop branch
- `pr-<number>` - Pull request builds

### Using Published Images
```bash
# Pull and run the latest image
docker pull ghcr.io/anirugu/web:latest
docker run -d -p 8080:8080 ghcr.io/anirugu/web:latest
```

### Security Features
- **Vulnerability Scanning**: Trivy security scanner runs on every build
- **Build Attestation**: Cryptographic proof of build integrity
- **Multi-platform**: Supports both AMD64 and ARM64 architectures