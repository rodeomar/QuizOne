# QuizOne
QuizOne where users can create, share, and participate in quizzes on various topics. Users will register, create quizzes, take quizzes created by others, and receive scores and feedback.



```diff
- Under Construction
```


## Getting Started

1. Clone this repository to your local machine:

   ```sh
   git clone https://github.com/rodeomar/QuizOne.git
   ```

2. Navigate to the project directory:

   ```sh
   cd QuizOne
   ```

3. Create and Update the `appsettings.json` file with your database connection string.
  ```json
  {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=db_name;User=username;Password=password;"
      }
  }
  ```
   
5. Install the required packages:

   ```sh
   dotnet restore
   ```
6. Craete migrations:
  ```sh
  dotnet ef migrations Intial
  ```
6. Apply database migrations:

   ```sh
   dotnet ef database update
   ```

7. Run the Application:

   ```sh
   dotnet run
   ```
