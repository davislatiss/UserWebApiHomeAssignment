# UserWebApiHomeAssignment

Launch the project from KleintechTestTask.sln file.

I started with creating the persons and address classes and class properties as given in the example.
Added the sql Db for data storage as instructed. Created methods for adding, deleting and updating marriage status
for persons in the admin controler. If given more time I would work on improving the project architecture- layering and 
implementing interfaces for models. Noticed problems with self referencing in the person class where the spouse is a
reference to the person object. This should also be fixed if possible.
I am storing age as a DateTime object so a method for showing the actual age for each person should be created as well. 

Overall I am satisfied with the result but many improvements should be made.
