No, the `Book` class **does not** follow the **Single Responsibility Principle (SRP)** because it has **multiple responsibilities**:

### **Violations of SRP in the `Book` class**
1. **Encapsulates Book Data** → `getTitle()`, `getAuthor()`, `turnPage()`, `getCurrentPage()`
2. **Handles Library Management** → `getLocation()`
3. **Handles Persistence (Saving the book)** → `save()`

👉 A class following **SRP** should have **only one reason to change**. In this case, `Book` could change for multiple reasons:
- If we modify how a book's data is represented.
- If we change how books are **located in the library**.
- If we change how books are **stored/saved** (file storage, database, etc.).

---

### To follow SRP, we should split responsibilities into **separate classes**:

#### **1️⃣ Book class (Core Book Data & Page Management)**
```php
class Book {
    private $title;
    private $author;
    private $currentPage = 1;

    public function __construct($title, $author) {
        $this->title = $title;
        $this->author = $author;
    }

    public function getTitle() {
        return $this->title;
    }

    public function getAuthor() {
        return $this->author;
    }

    public function turnPage() {
        $this->currentPage++;
    }

    public function getCurrentPage() {
        return "Page " . $this->currentPage;
    }
}
```

#### **2️⃣ LibraryLocation class (Manages Book Location)**
```php
class LibraryLocation {
    private $shelfNumber;
    private $roomNumber;

    public function __construct($shelfNumber, $roomNumber) {
        $this->shelfNumber = $shelfNumber;
        $this->roomNumber = $roomNumber;
    }

    public function getLocation() {
        return "Shelf: " . $this->shelfNumber . ", Room: " . $this->roomNumber;
    }
}
```

#### **3️⃣ BookPersistence class (Handles Saving the Book)**
```php
class BookPersistence {
    public function save(Book $book) {
        $filename = '/documents/' . $book->getTitle() . ' - ' . $book->getAuthor();
        file_put_contents($filename, serialize($book));
    }
}
```

#### **4️⃣ Printer Interface (Handles Book Printing)**
( This part was already correct)
```php
interface Printer {
    function printPage($page);
}

class PlainTextPrinter implements Printer {
    function printPage($page) {
        echo $page;
    }
}

class HtmlPrinter implements Printer {
    function printPage($page) {
        echo '<div style="single-page">' . $page . '</div>';
    }
}
```

---

### **After refactoring**
1. **SRP Compliance** → Each class now has **only one responsibility**.
2. **Separate Reason To Change** → Changes in book storage, library location, or printing won't affect the core `Book` class.
3. **Extensibility** → We can add new storage options (database, cloud) or printers (PDF, Markdown) **without modifying the `Book` class**.