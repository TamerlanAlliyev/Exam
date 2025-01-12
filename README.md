**Mini School App**  

The Mini School App is a project developed based on SOLID principles and implemented using the ASP.NET Core 8 MVC platform with the "Clean Architecture" approach. Below are the development stages:  

**Design and Structure:**  
- Created using Figma to define the layout and structure of the project.  
- Link: [figma.com]([https://figma.com](https://www.figma.com/design/54T6jSH7u5IJsj1wglU1s2/Untitled?node-id=1-2&t=jGcAx8Ou4Xh5cbHp-0))  

**Database Design:**  
- A robust database structure was created using modern database design methodologies.  

**Frontend Development:**  
- An interactive and responsive user interface was built using HTML, CSS, and JavaScript.  

**Backend Development:**  
- A high-performance and easily manageable backend was developed using ASP.NET Core 8 MVC.  

**Database Integration:**  
- Microsoft SQL Server (MS SQL) was used for data management and storage.  

**Entity Framework Integration:**  
- Database access and management were implemented using the Entity Framework Code-First approach.  
- Optimized data queries were executed using LINQ.  


**Usage Instructions**

Follow the steps below to effectively use the Mini School App:

Create a Teacher:

Begin by creating a teacher profile in the system.
Create a Class and Assign a Teacher:

Add a new class and assign a teacher to it during the creation process.
Create a Student and Assign to a Class:

Register a new student and assign them to a specific class.
The assigned teacher for the selected class will automatically be associated with the student.
Create a Lesson and Assign to a Class:

Add a lesson and link it to the relevant class.
Announce an Exam for the Lesson:

Create an exam for the lesson.
The exam has two statuses:
Pending (default status upon creation).
Conducted (status changes after the exam is completed).
Record Exam Results:

Add the exam results for students, which will automatically update the exam status to Conducted.
