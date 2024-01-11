Course
Lesson
Exercice (quiz or code)
Quiz variants
Student
Teacher
Submissions

One course has many Lessons
one course has one or many Teacher
one course has many students
Teacher has many courses
One lesson has code exercise or quiz exercise 
(quiz) exercise has quiz variants
one exercise has many submisions
one student has many submisions




Course
id : string
Name : text

Lesson
id : string
courseId : string
Name : text

Exercise
id : string
lessonId : string
enunciation : string
type: int ( 0 code, 1 quiz)


quiz variants
id : string
exerciseId : string
text : string
isCorect : bool


Student
id : string
firstname : string
lastname : string
email : string
password (encrypted) : string
courseId : string


Teacher
id : string
firstname : string
lastname : string
email : string
password (encrypted)

Submissions
points : int (% out of 100)
studentId : string
exerciseId : string

Course_Teacher
courseId: string
TeacherId : string

