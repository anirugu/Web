using Web.Models;

namespace Web.Services;

public interface IBlogService
{
    Task<List<BlogPost>> GetAllPostsAsync();
    Task<BlogPost?> GetPostBySlugAsync(string slug);
    Task<Dictionary<int, List<BlogPost>>> GetPostsByYearAsync();
}

public class BlogService : IBlogService
{
    private readonly List<BlogPost> _posts;

    public BlogService()
    {
        _posts = new List<BlogPost>
        {
            new BlogPost
            {
                Id = 1,
                Title = "Getting Started with Blazor Server",
                Slug = "getting-started-blazor-server",
                Content = @"# Getting Started with Blazor Server

Blazor Server is a powerful framework for building interactive web applications using C# instead of JavaScript. In this post, we'll explore the fundamentals and get you up and running.

## What is Blazor Server?

Blazor Server is a hosting model for Blazor applications where the UI logic runs on the server, and UI updates are sent to the browser over a SignalR connection.

## Benefits

- **Server-side rendering**: Fast initial load times
- **Real-time updates**: Built-in SignalR integration
- **C# everywhere**: No need for JavaScript
- **Security**: Sensitive logic stays on the server

## Getting Started

First, create a new Blazor Server project:

```bash
dotnet new blazorserver -n MyBlazorApp
cd MyBlazorApp
dotnet run
```

This will scaffold a complete Blazor Server application with sample components and pages.

## Key Concepts

### Components
Components are the building blocks of Blazor applications. They're defined using Razor syntax (.razor files).

### Data Binding
Blazor provides powerful two-way data binding capabilities using the `@bind` directive.

### Event Handling
Handle DOM events directly in C# using event handlers like `@onclick`.

## Conclusion

Blazor Server provides an excellent way to build modern web applications using familiar .NET technologies. The combination of server-side rendering and real-time updates makes it perfect for many scenarios.",
                Excerpt = "Learn the fundamentals of Blazor Server and how to build interactive web applications using C# instead of JavaScript.",
                PublishedDate = new DateTime(2024, 6, 15),
                Author = "Anirudha Gupta",
                Tags = new List<string> { "Blazor", "ASP.NET Core", "Web Development" }
            },
            new BlogPost
            {
                Id = 2,
                Title = "Modern CSS Grid Layouts",
                Slug = "modern-css-grid-layouts",
                Content = @"# Modern CSS Grid Layouts

CSS Grid has revolutionized how we approach layout design on the web. Let's explore some modern patterns and techniques.

## The Power of CSS Grid

CSS Grid Layout excels at two-dimensional layouts, where you need to control both rows and columns simultaneously.

```css
.grid-container {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
    gap: 2rem;
}
```

## Common Grid Patterns

### The Holy Grail Layout
```css
.holy-grail {
    display: grid;
    grid-template: 
        'header header header' auto
        'nav main aside' 1fr
        'footer footer footer' auto
        / 200px 1fr 200px;
    min-height: 100vh;
}
```

### Card Grid
```css
.card-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
    gap: 1.5rem;
}
```

## Advanced Techniques

- **Subgrid**: For nested grid layouts
- **Grid areas**: Named template areas for semantic layouts
- **Auto-placement**: Let the browser handle item positioning

## Browser Support

CSS Grid has excellent browser support across all modern browsers. Use `@supports` for graceful degradation:

```css
@supports (display: grid) {
    .grid-container {
        display: grid;
    }
}
```

Grid Layout is the future of CSS layouts. Embrace its power!",
                Excerpt = "Explore modern CSS Grid layout patterns and techniques for creating flexible, responsive designs.",
                PublishedDate = new DateTime(2024, 5, 22),
                Author = "Anirudha Gupta",
                Tags = new List<string> { "CSS", "Grid", "Layout", "Frontend" }
            },
            new BlogPost
            {
                Id = 3,
                Title = "Building RESTful APIs with ASP.NET Core",
                Slug = "building-restful-apis-aspnet-core",
                Content = @"# Building RESTful APIs with ASP.NET Core

RESTful APIs are the backbone of modern web applications. Let's explore how to build robust, scalable APIs using ASP.NET Core.

## What is REST?

REST (Representational State Transfer) is an architectural style for designing networked applications. It uses standard HTTP methods and status codes.

## Key Principles

1. **Stateless**: Each request contains all information needed
2. **Resource-based**: URLs represent resources
3. **HTTP methods**: Use appropriate verbs (GET, POST, PUT, DELETE)
4. **Status codes**: Return meaningful HTTP status codes

## Creating a Controller

```csharp
[ApiController]
[Route('api/[controller]')]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet('{id}')]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
            return NotFound();
        
        return Ok(product);
    }
}
```

## Best Practices

- **Versioning**: Version your APIs for backward compatibility
- **Pagination**: Implement pagination for large datasets
- **Validation**: Use data annotations and model validation
- **Error handling**: Implement global exception handling
- **Documentation**: Use Swagger/OpenAPI for API documentation

## Security Considerations

- Authentication and authorization
- Input validation
- Rate limiting
- CORS configuration

Building great APIs requires attention to design, performance, and security. Start with these fundamentals and iterate based on your needs.",
                Excerpt = "Learn how to design and implement robust RESTful APIs using ASP.NET Core with best practices and security considerations.",
                PublishedDate = new DateTime(2024, 4, 10),
                Author = "Anirudha Gupta",
                Tags = new List<string> { "ASP.NET Core", "API", "REST", "Backend" }
            },
            new BlogPost
            {
                Id = 4,
                Title = "JavaScript ES2024 Features",
                Slug = "javascript-es2024-features",
                Content = @"# JavaScript ES2024 Features

JavaScript continues to evolve with each new ECMAScript release. Let's explore the exciting new features in ES2024.

## Array Grouping

The new `Object.groupBy()` method makes it easy to group array elements:

```javascript
const people = [
    { name: 'Alice', age: 25 },
    { name: 'Bob', age: 30 },
    { name: 'Charlie', age: 25 }
];

const groupedByAge = Object.groupBy(people, person => person.age);
// { 25: [{ name: 'Alice', age: 25 }, { name: 'Charlie', age: 25 }], 30: [{ name: 'Bob', age: 30 }] }
```

## Promise.withResolvers()

A new utility for creating promises with external resolvers:

```javascript
const { promise, resolve, reject } = Promise.withResolvers();

// Use resolve/reject from outside the promise
setTimeout(() => resolve('Success!'), 1000);
```

## Temporal API (Stage 3)

A modern date/time API to replace the problematic Date object:

```javascript
const now = Temporal.Now.instant();
const date = Temporal.PlainDate.from('2024-06-15');
const duration = Temporal.Duration.from({ hours: 2, minutes: 30 });
```

## Array.fromAsync()

Create arrays from async iterables:

```javascript
const asyncIterable = {
    async *[Symbol.asyncIterator]() {
        yield 1;
        yield 2;
        yield 3;
    }
};

const array = await Array.fromAsync(asyncIterable);
// [1, 2, 3]
```

## Regex v Flag

Enhanced Unicode support in regular expressions:

```javascript
const regex = /[\p{Script=Greek}]/v;
console.log(regex.test('α')); // true
```

These features continue to make JavaScript more powerful and developer-friendly. Stay tuned for more exciting updates!",
                Excerpt = "Discover the latest JavaScript ES2024 features including array grouping, Promise.withResolvers(), and the Temporal API.",
                PublishedDate = new DateTime(2024, 3, 8),
                Author = "Anirudha Gupta",
                Tags = new List<string> { "JavaScript", "ES2024", "Frontend", "Programming" }
            },
            new BlogPost
            {
                Id = 5,
                Title = "Docker for .NET Developers",
                Slug = "docker-for-dotnet-developers",
                Content = @"# Docker for .NET Developers

Docker has become an essential tool for modern .NET development. Let's explore how to containerize your .NET applications effectively.

## Why Docker?

- **Consistency**: Same environment across development, testing, and production
- **Isolation**: Applications run in isolated containers
- **Portability**: Run anywhere Docker is supported
- **Scalability**: Easy horizontal scaling

## Creating a Dockerfile

Here's a multi-stage Dockerfile for a .NET 8 application:

```dockerfile
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY [""*.csproj"", ""./]
RUN dotnet restore

# Copy source code
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT [""dotnet"", ""YourApp.dll""]
```

## Best Practices

### Multi-stage Builds
Use multi-stage builds to keep your final image small:
- Build stage: Contains SDK and build tools
- Runtime stage: Contains only the runtime and your app

### Layer Optimization
Order your Dockerfile commands from least to most frequently changing:

```dockerfile
# Dependencies change less frequently
COPY *.csproj ./
RUN dotnet restore

# Source code changes more frequently
COPY . .
RUN dotnet publish
```

### Security
- Use specific image tags, not `latest`
- Run as non-root user
- Use minimal base images
- Scan images for vulnerabilities

## Docker Compose

For local development with multiple services:

```yaml
version: '3.8'
services:
  web:
    build: .
    ports:
      - ""5000:80""
    depends_on:
      - database
    environment:
      - ConnectionStrings__DefaultConnection=Server=database;Database=MyApp;User=sa;Password=YourPassword123!;

  database:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=YourPassword123!
    volumes:
      - sql_data:/var/opt/mssql

volumes:
  sql_data:
```

## Development Workflow

1. Write your application code
2. Create a Dockerfile
3. Build the image: `docker build -t myapp .`
4. Run the container: `docker run -p 5000:80 myapp`
5. Test and iterate

Docker simplifies deployment and ensures consistency across environments. Start containerizing your .NET applications today!",
                Excerpt = "Learn how to containerize .NET applications with Docker, including best practices for Dockerfiles and development workflows.",
                PublishedDate = new DateTime(2023, 12, 14),
                Author = "Anirudha Gupta",
                Tags = new List<string> { "Docker", ".NET", "DevOps", "Containers" }
            },
            new BlogPost
            {
                Id = 6,
                Title = "Responsive Design with CSS Container Queries",
                Slug = "responsive-design-css-container-queries",
                Content = @"# Responsive Design with CSS Container Queries

Container queries are revolutionizing responsive design by allowing components to respond to their container's size rather than the viewport.

## The Problem with Media Queries

Traditional media queries respond to viewport size:

```css
@media (max-width: 768px) {
    .card {
        flex-direction: column;
    }
}
```

But what if the same component appears in different contexts with different available space?

## Enter Container Queries

Container queries let components respond to their container's dimensions:

```css
.card-container {
    container-type: inline-size;
    container-name: card;
}

@container card (max-width: 300px) {
    .card {
        flex-direction: column;
    }
    
    .card-image {
        width: 100%;
    }
}
```

## Container Types

- `inline-size`: Query the inline dimension (width in horizontal writing mode)
- `block-size`: Query the block dimension (height in horizontal writing mode)  
- `size`: Query both dimensions

## Practical Examples

### Responsive Card Component

```css
.card-wrapper {
    container-type: inline-size;
}

.card {
    display: flex;
    gap: 1rem;
}

@container (max-width: 400px) {
    .card {
        flex-direction: column;
    }
    
    .card-content {
        text-align: center;
    }
}
```

### Adaptive Navigation

```css
.nav-container {
    container-type: inline-size;
}

@container (max-width: 600px) {
    .nav-menu {
        display: none;
    }
    
    .nav-toggle {
        display: block;
    }
}
```

## Browser Support

Container queries are supported in:
- Chrome 105+
- Firefox 110+
- Safari 16.0+

Use feature detection for progressive enhancement:

```css
@supports (container-type: inline-size) {
    .container {
        container-type: inline-size;
    }
}
```

## Benefits

- **Component-focused**: Components adapt based on available space
- **Reusable**: Same component works in different layouts
- **Predictable**: More intuitive than viewport-based queries
- **Maintainable**: Easier to manage component-specific styles

Container queries represent the future of responsive design. Start experimenting with them in your projects!",
                Excerpt = "Discover how CSS Container Queries are changing responsive design by allowing components to adapt to their container size.",
                PublishedDate = new DateTime(2023, 10, 5),
                Author = "Anirudha Gupta",
                Tags = new List<string> { "CSS", "Container Queries", "Responsive Design", "Frontend" }
            }
        };
    }

    public Task<List<BlogPost>> GetAllPostsAsync()
    {
        return Task.FromResult(_posts.Where(p => p.IsPublished).ToList());
    }

    public Task<BlogPost?> GetPostBySlugAsync(string slug)
    {
        var post = _posts.FirstOrDefault(p => p.Slug == slug && p.IsPublished);
        return Task.FromResult(post);
    }

    public Task<Dictionary<int, List<BlogPost>>> GetPostsByYearAsync()
    {
        var postsByYear = _posts
            .Where(p => p.IsPublished)
            .OrderByDescending(p => p.PublishedDate)
            .GroupBy(p => p.PublishedDate.Year)
            .ToDictionary(g => g.Key, g => g.ToList());
        
        return Task.FromResult(postsByYear);
    }
}