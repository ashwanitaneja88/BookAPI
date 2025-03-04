# Steps

## 1. Open the solution file
   
## 2. compile the code, Select BookAPI as run as startup Project and run the application
   
## 3. Swagger UI will be visible, Below mentioned APIs will be displayed

Function | API | Type | Url
------------ | ------------ | ------------- | ------------
Get all the book records | api/books | GET |https://localhost:44394/api/books
Save the new book record |api/books | POST |https://localhost:44394/api/books
Get book record by id | api/books/id | GET |https://localhost:44394/api/books/1
Update book record | api/books/id | PUT |https://localhost:44394/api/books/1
delete book record | api/books/id | DELETE |https://localhost:44394/api/books/1

   
## 4. expand the API and click "Try it Out" button, Add the parameter and click on execute
   
## 5. Or else, Postman can be used to create the respective API call 
   
## 6. To run the Test Cases, Open BooksController.UnitTests file in BookAPI.UnitTests project 
   
## 7. Run all the test cases by right click and run the tests
   
## 8. Or Go to Test Explorer, select the root level, and click on Run
