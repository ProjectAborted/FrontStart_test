/ LibrarySystem.sln
├── .gitignore                    # Standard .NET ignore file
├── README.md                     # Group/Team name and documentation
├── src/
│   ├── Library.Domain/           # Core Entities and Repository Contracts
│   │   ├── Entities/             # Book.cs, Member.cs, BorrowRecord.cs
│   │   └── Interfaces/           # IBookRepository.cs, IMemberRepository.cs
│   │
│   ├── Library.Application/      # Business Logic and DTOs
│   │   ├── DTOs/                 # Requests (CreateBookDto) and Responses (BookResponseDto)
│   │   ├── Interfaces/           # IBookService.cs, IMemberService.cs
│   │   ├── Services/             # BookService.cs (Handles borrowing/return rules)
│   │   └── Exceptions/           # Custom exceptions for Global Error Handling
│   │
│   ├── Library.Infrastructure/   # Data Access (Entity Framework)
│   │   ├── Data/                 # AppDbContext.cs (Handles Concurrency tokens)
│   │   ├── Repositories/         # BookRepository.cs (Async DB operations)
│   │   └── Migrations/           # EF Core Database migrations
│   │
│   └── Library.Api/              # Controllers and Entry Point
│       ├── Controllers/          # BooksController.cs, MembersController.cs
│       ├── Middleware/           # GlobalExceptionMiddleware.cs
│       ├── Program.cs            # Dependency Injection (DI) & Caching setup
│       └── appsettings.json      # Connection strings
└── tests/                        # Unit tests for Services/Logic
