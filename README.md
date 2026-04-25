/ LibrarySystem.sln
├── .gitignore                    # Standard .NET ignore file
├── README.md                     # Group/Team name and documentation
├── src/
│   ├── Library.Api/ (Entry Point & Controllers)
│   │   ├── Controllers/
│   │   │   ├── BooksController.cs       # Routes for CRUD on Books
│   │   │   ├── BorrowsController.cs     # Routes for Borrowing/Returning/History
│   │   │   └── MembersController.cs     # Routes for Member management
│   │   ├── Program.cs                   # Registers Services, Repos, and DB
│   │   └── appsettings.json             # DB Connection strings
│   │
│   ├── Library.Application/ (Business Logic & DTOs)
│   │   ├── DTOs/
│   │   │   ├── BookDtos.cs              # Request/Response models for Books
│   │   │   ├── MemberDtos.cs            # Added: MembershipDate field
│   │   │   └── BorrowDtos.cs            # Added: BorrowDate, ReturnDate, Status fields
│   │   ├── Interfaces/                  # Contracts for the Services
│   │   └── Services/
│   │       ├── BookService.cs           # Book logic (Validating copy counts)
│   │       ├── MemberService.cs         # Member logic (Setting MembershipDate)
│   │       └── BorrowService.cs         # Core logic (Updating AvailableCopies)
│   │
│   ├── Library.Domain/ (Core Models)
│   │   ├── Entities/
│   │   │   ├── Book.cs                  # Props: Title, Author, ISBN, Copies
│   │   │   ├── Member.cs                # Props: FullName, Email, MembershipDate
│   │   │   └── BorrowRecord.cs          # Props: Dates and Status ("Borrowed"/"Returned")
│   │   └── Interfaces/                  # Repository contracts (IBookRepository, etc.)
│   │
│   └── Library.Infrastructure/ (Data Access)
│       ├── Data/
│       │   └── AppDbContext.cs          # EF Core context for DB tables
│       └── Repositories/
│           ├── BookRepository.cs        # Direct Database queries for Books
│           ├── MemberRepository.cs      # Direct Database queries for Members
│           └── BorrowRepository.cs      # Added: Logic to find "Active" borrows
│
└── Library.sln
