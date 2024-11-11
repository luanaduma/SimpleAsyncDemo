# Simple Async Demo

A C# ASP.NET Core project to explore and understand asynchronous programming mechanisms. This project demonstrates the differences between synchronous, asynchronous, and parallel processing through a practical application that downloads and processes website data.

![Project Banner](https://via.placeholder.com/1200x400?text=Simple+Async+Demo) <!-- Replace with a screenshot/banner of your app -->

---

## **Table of Contents**
- [Purpose](#purpose)
- [Features](#features)
- [Screenshots](#screenshots)
- [Technologies Used](#technologies-used)
- [Setup and Run](#setup-and-run)
- [How It Works](#how-it-works)
- [Future Enhancements](#future-enhancements)

---

## **Purpose**
This project is a hands-on learning tool to:
- Explore C#'s asynchronous programming features, including `async`/`await` and `Task.WhenAll`.
- Understand the difference between blocking (synchronous) and non-blocking (asynchronous) operations.
- Implement parallel processing to improve performance for I/O-bound tasks.
- Demonstrate real-time client-server communication using SignalR.

---

## **Features**
1. **Run Sync**
   - Executes tasks sequentially.
   - Demonstrates the blocking nature of synchronous programming.
   
   Example Output:
   ```
   https://www.yahoo.com/ downloaded: 12001 characters long.
   https://www.microsoft.com/ downloaded: 10234 characters long.
   ```

2. **Run Async**
   - Demonstrates non-blocking asynchronous programming using `async` and `await`.
   - Sends real-time progress updates to the UI using SignalR.

3. **Run Parallel**
   - Executes multiple tasks concurrently using `Task.WhenAll`.
   - Displays real-time progress updates for parallel tasks via SignalR.

4. **Real-Time Updates**
   - Real-time notifications of progress using SignalR for both async and parallel operations.

---

## **Screenshots**

### **1. Home Page**
The main interface with options to run synchronous, asynchronous, and parallel operations.

![Home Page Screenshot](https://via.placeholder.com/1200x600?text=Home+Page)

---

### **2. Run Sync Output**
Output after running synchronous operations.

![Run Sync Screenshot](https://via.placeholder.com/1200x600?text=Run+Sync+Output)

---

### **3. Real-Time Updates (SignalR Integration)**
Live updates for asynchronous and parallel operations.

![SignalR Updates Screenshot](https://via.placeholder.com/1200x600?text=Real-Time+Updates)

---

## **Technologies Used**
- **ASP.NET Core MVC**: Backend framework.
- **C# Asynchronous Programming**: `async`/`await`, `Task.WhenAll`.
- **SignalR**: Real-time client-server communication.
- **Bootstrap**: Frontend styling and responsive design.
- **Font Awesome**: Icons for better visual appeal.

---

## **Setup and Run**

### **Prerequisites**
- .NET 6 SDK or later
- A code editor (e.g., Visual Studio, Visual Studio Code)
- A web browser

### **Steps**
1. Clone this repository:
   ```bash
   git clone https://github.com/luanaduma/simple-async-demo.git
   cd simple-async-demo
   ```

2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Open your browser and navigate to:
   ```
   http://localhost:5000
   ```

---

## **How It Works**

### **Data Flow**
1. The user selects an operation (Sync, Async, or Parallel).
2. For `Run Sync`:
   - Tasks are executed one by one, blocking the main thread.
3. For `Run Async`:
   - Tasks execute asynchronously.
   - SignalR sends progress updates in real-time.
4. For `Run Parallel`:
   - Multiple tasks are executed concurrently using `Task.WhenAll`.
   - SignalR broadcasts progress updates for each task.

### **Real-Time Updates**
- SignalR is used to send live progress messages to the UI.
- Separate output sections display updates for `Run Async` and `Run Parallel`.

---

## **Future Enhancements**
- **Error Reporting**: Improve error-handling UI for failed tasks.
- **Custom URL Input**: Allow users to provide their own list of URLs for testing.
- **Performance Metrics**: Display charts comparing performance across Sync, Async, and Parallel operations.
- **Testing**: Add automated unit and integration tests.

---

## **Contributing**
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

---

## **License**
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## **Acknowledgments**
- **Microsoft Docs** for guidance on asynchronous programming.
- **Font Awesome** for icons.
- **SignalR** for simplifying real-time communication.
